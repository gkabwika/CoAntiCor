using CoAntiCor.API.Services;
using CoAntiCor.Core.Domain;
using CoAntiCor.Core.DTO;
using CoAntiCor.Core.Interfaces;
using CoAntiCor.Core.Model;
using CoAntiCor.Core.Services;
using CoAntiCor.Infrastructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CoAntiCor.API.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ComplaintDraftController : ControllerBase
    {
        private readonly CoAntiCorDbContext _db;
        private readonly IComplaintNumberGenerator _numberGenerator;
        private readonly IAttachmentService _attachmentService;
        private readonly INotificationService _notificationService;
        private readonly IAuditService _audit;
        private readonly IComplaintDraftService _draftService;
        private readonly IQrCodeService _qrService;

        public ComplaintDraftController(
            CoAntiCorDbContext db,
            IComplaintNumberGenerator numberGenerator,
            IAttachmentService attachmentService,
            INotificationService notificationService, IAuditService audit, IComplaintDraftService draftService, IQrCodeService qrService)
        {
            _db = db;
            _numberGenerator = numberGenerator;
            _attachmentService = attachmentService;
            _notificationService = notificationService;
            _audit = audit;
            _draftService = draftService;
            _qrService = qrService;

        }

        [Authorize(Roles = "Citizen")]
        [HttpGet("drafts")]
        public async Task<ActionResult<List<ComplaintDraftListItemDto>>> GetMyDrafts()
        {
            var userId = Guid.Parse(User.FindFirst("sub")!.Value);

            var drafts = await _db.ComplaintDrafts
                .Where(d => d.ReporterUserId == userId && !d.IsCompleted)
                .OrderByDescending(d => d.LastUpdatedUtc)
                .Select(d => new ComplaintDraftListItemDto
                {
                    DraftId = d.Id,
                    CurrentStep = d.CurrentStep,
                    LastUpdatedUtc = d.LastUpdatedUtc
                })
                .ToListAsync();

            return Ok(drafts);
        }

        [HttpPost("drafts/v2/save")]
        public async Task<IActionResult> SaveDraft([FromBody] ComplaintDraftState state, Guid? userId = default, bool isLinkClicked = false)
        {
            var result = await _draftService.SaveDraftV2Async(state, userId, isLinkClicked);

            if (result.Conflict)
            {
                return Conflict(new DraftConflictDto
                {
                    ServerStateJson = result.ServerStateJson!,
                    ServerVersion = result.ServerVersion!.Value
                });
            }
            return Ok();
        }

        [Authorize(Roles = "Citizen")]
        [HttpDelete("drafts/{draftId:guid}")]
        public async Task<IActionResult> DeleteDraft(Guid draftId)
        {
            var userId = Guid.Parse(User.FindFirst("sub")!.Value);

            var draft = await _db.ComplaintDrafts.FindAsync(draftId);
            if (draft is null || draft.ReporterUserId != userId)
                return NotFound();

            _db.ComplaintDrafts.Remove(draft);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [AllowAnonymous]
        [HttpPost("drafts/access")]
        public async Task<ActionResult<Guid>> LoadDraftByAccessCode([FromBody] string code)
        {
            var draft = await _db.ComplaintDrafts
                .FirstOrDefaultAsync(d => d.AccessCode == code && !d.IsCompleted);

            if (draft is null)
                return NotFound();

            return Ok(draft.Id);
        }

        /// <summary>
        ///  This endpoint generates a QR code that encodes a URL containing the draftId, allowing users to easily load their complaint draft on another device by scanning the QR code. The QR code is valid for a limited time and can only be used once for security reasons.   
        /// </summary>
        /// <param name="draftId"></param>
        /// <returns></returns>
        [HttpGet("drafts/{draftId:guid}/qr")]
        public async Task<IActionResult> GetDraftQr(Guid draftId)
        {
            var draft = await _db.ComplaintDrafts.FindAsync(draftId);
            if (draft is null) return NotFound();

            var url = $"{Request.Scheme}://{Request.Host}/wizard?draftId={draftId}";
            // Generate QR code that encodes the URL to load the draft on another device
            var png = _qrService.GenerateQrCode(url);

            return File(png, "image/png");
        }

  
        //
        // This endpoint is called by the new device after scanning the QR code or entering the access code
        // It verifies the token and returns the draftId if valid, allowing the new device to load the draft
        [AllowAnonymous]
        [HttpPost("drafts/link-device")]
        public async Task<IActionResult> LinkDevice([FromBody] DeviceLinkRequest request)
        {
            var draft = await _db.ComplaintDrafts.FindAsync(request.DraftId);
            if (draft is null) return NotFound();

            if (draft.DeviceLinkToken != request.Token ||
                draft.DeviceLinkTokenExpiresUtc < DateTime.UtcNow)
                return Unauthorized("Invalid or expired token.");

            // Success: return draftId so the new device can load it
            return Ok(new { draftId = draft.Id });
        }
        /*
         2.6. UI Flow
            On Device A (Laptop):
            User clicks “Link another device”:
            - Show QR code
            - Show PIN
            - Show expiration countdown
            On Device B (Phone):
            User scans QR → opens /link-device page:
            - Page calls API with token
            - If valid → redirect to /wizard?draftId=...
            - If invalid → show error
         Alternative: Enter PIN manually
         User goes to /link-device-pin and enters PIN.

         */
        // This endpoint allows linking a device using a PIN code instead of a token, for users who prefer that method
        // The user would first enter the PIN on the original device to generate a token, then use that token and PIN on the new device to link
        // PIN Verification Endpoint: Verifies the PIN and token, and if valid, returns the draftId for the new device to load the draft

        [AllowAnonymous]
        [HttpPost("drafts/link-pin")]
        public async Task<IActionResult> LinkDeviceByPin([FromBody] PinLinkRequest request)
        {
            var draft = await _db.ComplaintDrafts
                .FirstOrDefaultAsync(d => d.DeviceLinkToken == request.Token);

            if (draft is null || draft.DeviceLinkTokenExpiresUtc < DateTime.UtcNow)
                return Unauthorized();

            if (draft.DeviceLinkPin != request.Pin)
                return Unauthorized("Invalid PIN.");

            return Ok(new { draftId = draft.Id });
        }

        // Analytics endpoint for complaint drafts, accessible only to Managers and Executives
        // Provides insights into draft usage, step drop-off rates, device types, and daily draft creation trends
        /*
         This dashboard gives internal staff visibility into how citizens use the reporting wizard:
            - How many drafts exist
            - How many are abandoned
            - Average time spent per step
            - Device types used
            - Completion rates
            - Drop‑off points
            - Draft activity heatmap

         */

        [Authorize(Roles = "Manager,Executive")]
        [HttpGet("drafts/analytics")]
        public async Task<ActionResult<DraftAnalyticsDto>> GetDraftAnalytics()
        {
            var drafts = await _db.ComplaintDrafts.ToListAsync();
            var activities = await _db.ComplaintDraftActivities.ToListAsync();

            var dto = new DraftAnalyticsDto
            {
                TotalDrafts = drafts.Count,
                ActiveDrafts = drafts.Count(d => !d.IsCompleted),
                CompletedDrafts = drafts.Count(d => d.IsCompleted),
                AbandonedDrafts = drafts.Count(d => !d.IsCompleted &&
                                                    d.LastUpdatedUtc < DateTime.UtcNow.AddDays(-30))
            };

            dto.StepDropoffCounts = activities
                .Where(a => a.Action == "StepCompleted")
                .GroupBy(a => a.StepNumber ?? 0)
                .ToDictionary(g => g.Key, g => g.Count());

            dto.DeviceTypeCounts = activities
                .GroupBy(a => a.DeviceType)
                .ToDictionary(g => g.Key, g => g.Count());

            dto.BrowserCounts = activities
                .GroupBy(a => a.Browser)
                .ToDictionary(g => g.Key, g => g.Count());

            dto.DailyDrafts = drafts
                .GroupBy(d => d.LastUpdatedUtc.Date)
                .Select(g => new DailyDraftCount { Date = g.Key, Count = g.Count() })
                .OrderBy(x => x.Date)
                .ToList();

            return Ok(dto);
        }

        /*
         This endpoint provides a detailed report of device security-related activities for a specific complaint draft, accessible only to Executives and Regulators. It includes:
            - Access entries: timestamps, device types, browsers, and IP addresses for each time the draft was accessed or autosaved.
            - Device link attempts: timestamps, success status, method (QR or PIN), and IP addresses for each attempt to link a new device to the draft.
         This information helps identify potential security issues, such as unauthorized access attempts or suspicious device usage patterns.
       
         2. Device Security Report (Regulators)
            This report helps regulators audit:
            - Suspicious device activity
            - Multiple devices accessing the same draft
            - Unusual IP changes
            - Possible tampering
            - Device linking attempts
            - Failed PIN/QR attempts

         */

        [Authorize(Roles = "Executive,Regulator")]
        [HttpGet("drafts/{draftId:guid}/device-security")]
        public async Task<ActionResult<DeviceSecurityReportDto>> GetDeviceSecurityReport(Guid draftId)
        {
            var activities = await _db.ComplaintDraftActivities
                .Where(a => a.DraftId == draftId)
                .ToListAsync();

            var dto = new DeviceSecurityReportDto
            {
                DraftId = draftId,
                AccessEntries = activities
                    .Where(a => a.Action == "Autosave" || a.Action == "StepCompleted")
                    .Select(a => new DeviceAccessEntry
                    {
                        TimestampUtc = a.TimestampUtc,
                        DeviceType = a.DeviceType,
                        Browser = a.Browser,
                        IpAddress = a.IpAddress
                    }).ToList(),

                LinkAttempts = activities
                    .Where(a => a.Action == "DeviceLinkAttempt")
                    .Select(a => new DeviceLinkAttempt
                    {
                        TimestampUtc = a.TimestampUtc,
                        Success = a.StepNumber == 1,
                        Method = a.DeviceName, // store "QR" or "PIN"
                        IpAddress = a.IpAddress
                    }).ToList()
            };

            return Ok(dto);
        }

        [Authorize(Roles = "Executive,Regulator")]
        [HttpGet("drafts/{draftId:guid}/suspicious-activity")]
        public async Task<ActionResult<SuspiciousActivityResult>> AnalyzeDraft(
                Guid draftId,
                [FromServices] ISuspiciousActivityDetector detector)
        {
            var result = await detector.AnalyzeDraftAsync(draftId);
            return Ok(result);
        }

        /*
         * Draft Heatmap Visualization (Per Province, Per Hour)
            This shows:
            - When citizens are most active
            - Which provinces generate the most drafts
            - Patterns of reporting behavior
            This is extremely useful for UX optimization and anti-corruption outreach.

         */

        [Authorize(Roles = "Manager,Executive")]
        [HttpGet("drafts/heatmap")]
        public async Task<ActionResult<DraftHeatmapDto>> GetDraftHeatmap()
        {
            var drafts = await _db.ComplaintDrafts.ToListAsync();

            var dto = new DraftHeatmapDto
            {
                DraftsByProvince = drafts
                    .GroupBy(d => d.StateJson.Contains("Province")
                        ? JsonDocument.Parse(d.StateJson).RootElement.GetProperty("Province").GetString() ?? "Unknown"
                        : "Unknown")
                    .ToDictionary(g => g.Key, g => g.Count()),

                DraftsByHour = drafts
                    .GroupBy(d => d.LastUpdatedUtc.Hour)
                    .ToDictionary(g => g.Key, g => g.Count())
            };

            return Ok(dto);
        }

        [Authorize(Roles = "Executive")]
        [HttpGet("drafts/ux-report")]
        public async Task<ActionResult<UxOptimizationReport>> GetUxReport(
            [FromServices] IUxAnalyzer analyzer)
        {
            return Ok(await analyzer.GenerateReportAsync());
        }


    }




    public class PinLinkRequest
    {
        public string Token { get; set; } = default!;
        public string Pin { get; set; } = default!;
    }
    public class DeviceLinkRequest
    {
        public Guid DraftId { get; set; }
        public string Token { get; set; } = default!;
    }
}
