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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CoAntiCor.API.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ComplaintsController : ControllerBase
    {
        private readonly CoAntiCorDbContext _db;
        private readonly IComplaintNumberGenerator _numberGenerator;
        private readonly IAttachmentService _attachmentService;
        private readonly INotificationService _notificationService;
        private readonly IAuditService _audit;

        public ComplaintsController(
            CoAntiCorDbContext db,
            IComplaintNumberGenerator numberGenerator,
            IAttachmentService attachmentService,
            INotificationService notificationService, IAuditService audit)
        {
            _db = db;
            _numberGenerator = numberGenerator;
            _attachmentService = attachmentService;
            _notificationService = notificationService;
            _audit = audit;
        }

        [HttpPost]
        public async Task<ActionResult<CreateComplaintResponse>> CreateComplaint(
            [FromBody] CreateComplaintRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // 1. Generate complaint number
            var complaintNumber = await _numberGenerator.GenerateAsync();

            // 2. Create complaint entity
            var complaint = new Complaint
            {
                Id = Guid.NewGuid(),
                ComplaintNumber = complaintNumber,
                Title = request.Title,
                Description = request.Description,
                IncidentTypeId = request.IncidentTypeId,
                IncidentCategoryId = request.IncidentCategoryId,
                IsAnonymous = request.IsAnonymous,
                ReporterName = request.IsAnonymous ? null : request.ReporterName,
                ReporterContactEmail = request.IsAnonymous ? null : request.ReporterEmail,
                ReporterContactPhone = request.IsAnonymous ? null : request.ReporterPhone,
                Province = request.Province,
                City = request.City,
                GovernmentOfficeId = request.GovernmentOfficeId,
                Status = ComplaintStatus.Open,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // 3. Save complaint first (so attachments can reference it)
            _db.Complaints.Add(complaint);
            await _db.SaveChangesAsync();

            // 4. Process attachments
            foreach (var file in request.Attachments)
            {
                var finalPath = await _attachmentService.MoveFromTempAsync(file.TempStoragePath);

                var attachment = new ComplaintAttachment
                {
                    Id = Guid.NewGuid(),
                    ComplaintId = complaint.Id,
                    FileName = file.FileName,
                    FileType = file.ContentType,
                    FileSize = file.Size,
                    StoragePath = finalPath,
                    UploadedAt = DateTime.UtcNow
                };

                _db.ComplaintAttachments.Add(attachment);
            }

            //Using audit service in key flow such as complaint creation to log important actions for accountability and traceability.
            await _audit.LogAsync(
                AuditActionType.ComplaintCreated,
                entityType: "Complaint",
                entityId: complaint.Id.ToString(),
                summary: $"Complaint {complaint.ComplaintNumber} created.",
                details: new
                {
                    complaint.ComplaintNumber,
                    complaint.IncidentTypeId,
                    complaint.IncidentCategoryId,
                    complaint.IsAnonymous
                });

            // 5. Create initial workflow phase
            var phase = new ProcessingPhase
            {
                Id = Guid.NewGuid(),
                ComplaintId = complaint.Id,
                PhaseType = ProcessingPhaseType.Intake,
                Status = ProcessingPhaseStatus.Open,
                StartedAt = DateTime.UtcNow
            };

            _db.ProcessingPhases.Add(phase);

            // 6. Add history entry
            var history = new ComplaintHistory
            {
                Id = Guid.NewGuid(),
                ComplaintId = complaint.Id,
                OldStatus = ComplaintStatus.Open,
                NewStatus = ComplaintStatus.Open,
                ChangedAt = DateTime.UtcNow,
                ChangedByUserId = Guid.Empty, // system
                Comment = "Complaint created"
            };

            _db.ComplaintHistories.Add(history);

            await _db.SaveChangesAsync();

            //audit service : status change via processing engine will also log status changes, but we log the initial creation here for completeness and to capture the initial state in the audit log.
            await _audit.LogAsync(
                AuditActionType.ComplaintStatusChanged,
                entityType: "Complaint",
                entityId: complaint.Id.ToString(),
                summary: $"Status changed from {history.OldStatus} to {history.NewStatus}.",
                details: new
                {
                    OldStatus = history.OldStatus.ToString(),
                    NewStatus = history.NewStatus.ToString(),
                    Comment = history.Comment
                });


            // 7. Send notifications
            if (!complaint.IsAnonymous)
            {
                await _notificationService.SendComplaintConfirmationAsync(
                    complaint.ReporterContactEmail,
                    complaint.ReporterContactPhone,
                    complaint.ComplaintNumber);
            }

            // 8. Return response
            return Ok(new CreateComplaintResponse
            {
                ComplaintId = complaint.Id,
                ComplaintNumber = complaint.ComplaintNumber
            });
        }

        [HttpPost("dashboard")]
        public async Task<ActionResult<ComplaintDashboardResult>> GetDashboardData(
    [FromBody] ComplaintDashboardFilter filter)
        {
            var query = _db.Complaints
                .Include(c => c.IncidentType)
                .Include(c => c.IncidentCategory)
                .Include(c => c.AssignedToUser)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Province))
                query = query.Where(c => c.Province == filter.Province);

            if (!string.IsNullOrWhiteSpace(filter.City))
                query = query.Where(c => c.City == filter.City);

            if (filter.IncidentTypeId.HasValue)
                query = query.Where(c => c.IncidentTypeId == filter.IncidentTypeId);

            if (filter.IncidentCategoryId.HasValue)
                query = query.Where(c => c.IncidentCategoryId == filter.IncidentCategoryId);

            if (filter.Status.HasValue)
                query = query.Where(c => c.Status == filter.Status);

            if (filter.AssignedToUserId.HasValue)
                query = query.Where(c => c.AssignedToUserId == filter.AssignedToUserId);

            if (filter.CreatedFrom.HasValue)
                query = query.Where(c => c.CreatedAt >= filter.CreatedFrom);

            if (filter.CreatedTo.HasValue)
                query = query.Where(c => c.CreatedAt <= filter.CreatedTo);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(c => c.CreatedAt)
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Select(c => new ComplaintListItemDto
                {
                    Id = c.Id,
                    ComplaintNumber = c.ComplaintNumber,
                    Title = c.Title,
                    IncidentType = c.IncidentType!.Name,
                    IncidentCategory = c.IncidentCategory!.Name,
                    Status = c.Status,
                    Province = c.Province!,
                    City = c.City!,
                    CreatedAt = c.CreatedAt,
                    AssignedTo = c.AssignedToUser != null ? c.AssignedToUser.UserName : null
                })
                .ToListAsync();

            return Ok(new ComplaintDashboardResult
            {
                Items = items,
                TotalCount = totalCount,
                Page = filter.Page,
                PageSize = filter.PageSize
            });
        }

        [Authorize(Roles = "Manager,Executive")]
        [HttpPost("{id:guid}/assign")]
        public async Task<IActionResult> AssignComplaint(Guid id, [FromBody] AssignComplaintRequest request)
        {
            if (id != request.ComplaintId) return BadRequest();

            var complaint = await _db.Complaints.FindAsync(id);
            if (complaint is null) return NotFound();

            var assignee = await _db.Users.FindAsync(request.AssignedToUserId);
            if (assignee is null) return BadRequest("Assignee not found.");

            complaint.AssignedToUserId = assignee.Id;
            complaint.UpdatedAt = DateTime.UtcNow;

            _db.ComplaintHistories.Add(new ComplaintHistory
            {
                Id = Guid.NewGuid(),
                ComplaintId = complaint.Id,
                OldStatus = complaint.Status,
                NewStatus = complaint.Status,
                ChangedAt = DateTime.UtcNow,
                ChangedByUserId = GetCurrentUserId(),
                Comment = $"Assigned to {assignee.UserName}. {request.Comment}"
            });

            await _db.SaveChangesAsync();
            return NoContent();
        }

        private Guid GetCurrentUserId()
        {
            return Guid.Parse(User.FindFirst("sub")!.Value);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ComplaintDetailDto>> GetComplaint(Guid id)
        {
            var complaint = await _db.Complaints
                .Include(c => c.IncidentType)
                .Include(c => c.IncidentCategory)
                .Include(c => c.Attachments)
                .Include(c => c.History).ThenInclude(h => h.ChangedByUser)
                .Include(c => c.ProcessingPhases).ThenInclude(p => p.AssignedToUser)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (complaint is null) return NotFound();

            var dto = new ComplaintDetailDto
            {
                Id = complaint.Id,
                ComplaintNumber = complaint.ComplaintNumber,
                Title = complaint.Title,
                Description = complaint.Description,
                IncidentType = complaint.IncidentType!.Name,
                IncidentCategory = complaint.IncidentCategory!.Name,
                Status = complaint.Status,
                Province = complaint.Province,
                City = complaint.City,
                CreatedAt = complaint.CreatedAt,
                ReporterName = complaint.IsAnonymous ? null : complaint.ReporterName,
                IsAnonymous = complaint.IsAnonymous,
                Attachments = complaint.Attachments.Select(a => new AttachmentDto
                {
                    Id = a.Id,
                    FileName = a.FileName,
                    FileType = a.FileType,
                    UploadedAt = a.UploadedAt
                }).ToList(),
                History = complaint.History
                    .OrderBy(h => h.ChangedAt)
                    .Select(h => new HistoryDto
                    {
                        ChangedAt = h.ChangedAt,
                        OldStatus = h.OldStatus,
                        NewStatus = h.NewStatus,
                        ChangedBy = h.ChangedByUser.UserName,
                        Comment = h.Comment
                    }).ToList(),
                Phases = complaint.ProcessingPhases
                    .OrderBy(p => p.StartedAt)
                    .Select(p => new ProcessingPhaseDto
                    {
                        PhaseType = p.PhaseType,
                        Status = p.Status,
                        StartedAt = p.StartedAt,
                        CompletedAt = p.CompletedAt,
                        AssignedTo = p.AssignedToUser != null ? p.AssignedToUser.UserName : null,
                        Comments = p.Comments
                    }).ToList()
            };

            return Ok(dto);
        }
        [Authorize(Roles = "Prosecutor,Executive")]
        [HttpGet("{id:guid}/dossier")]
        public async Task<IActionResult> GetTribunalDossier(Guid id, [FromServices] ITribunalDossierService dossierService)
        {
            var pdf = await dossierService.GenerateDossierPdfAsync(id);
       

            await _audit.LogAsync(
                AuditActionType.DossierGenerated,
                entityType: "Complaint",
                entityId: id.ToString(),  //complaintId
                summary: $"Tribunal dossier generated.",
                details: new { ComplaintId = id 
                });

            return File(pdf, "application/pdf", $"Dossier-{id}.pdf");
        }


        /// <summary>
        /// 1. Citizen-facing “Track my complaint” page
        /// We’ll support two modes:
        /// - Authenticated citizen: sees all their complaints.
        /// - Public tracking by complaint number + email/phone: limited view.
        /// 1.1. API: public tracking endpoint

        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [AllowAnonymous]
        [HttpPost("track")]
        public async Task<ActionResult<TrackComplaintResponse>> TrackComplaint([FromBody] TrackComplaintRequest request)
        {
            var complaint = await _db.Complaints
                .FirstOrDefaultAsync(c => c.ComplaintNumber == request.ComplaintNumber);

            if (complaint is null)
                return NotFound();

            // If not anonymous, require matching email or phone
            if (!complaint.IsAnonymous)
            {
                var emailMatches = !string.IsNullOrWhiteSpace(request.Email) &&
                                   complaint.ReporterContactEmail == request.Email;
                var phoneMatches = !string.IsNullOrWhiteSpace(request.Phone) &&
                                   complaint.ReporterContactPhone == request.Phone;

                if (!emailMatches && !phoneMatches)
                    return Unauthorized("Contact information does not match.");
            }

            var lastPublicComment = await _db.ComplaintHistories
                .Where(h => h.ComplaintId == complaint.Id)
                .OrderByDescending(h => h.ChangedAt)
                .Select(h => h.Comment)
                .FirstOrDefaultAsync();

            return Ok(new TrackComplaintResponse
            {
                ComplaintNumber = complaint.ComplaintNumber,
                Status = complaint.Status,
                CreatedAt = complaint.CreatedAt,
                Province = complaint.Province,
                City = complaint.City,
                LastPublicComment = lastPublicComment
            });
        }


        //1.2. API: authenticated citizen’s complaints
        [Authorize(Roles = "Citizen")]
        [HttpGet("mine")]
        public async Task<ActionResult<List<MyComplaintListItemDto>>> GetMyComplaints()
        {
            var userId = Guid.Parse(User.FindFirst("sub")!.Value);

            var items = await _db.Complaints
                .Where(c => c.ReporterUserId == userId)
                .OrderByDescending(c => c.CreatedAt)
                .Select(c => new MyComplaintListItemDto
                {
                    Id = c.Id,
                    ComplaintNumber = c.ComplaintNumber,
                    Title = c.Title,
                    Status = c.Status,
                    CreatedAt = c.CreatedAt
                })
                .ToListAsync();

            return Ok(items);
        }

        public class AuditLogFilter
        {
            public AuditActionType? ActionType { get; set; }
            public string? EntityType { get; set; }
            public string? EntityId { get; set; }
            public DateTime? From { get; set; }
            public DateTime? To { get; set; }
            public int Page { get; set; } = 1;
            public int PageSize { get; set; } = 50;
        }

        [Authorize(Roles = "Executive,Regulator")]
        [HttpPost("audit-logs")]
        public async Task<ActionResult<List<AuditLog>>> GetAuditLogs([FromBody] AuditLogFilter filter)
        {
            var query = _db.AuditLogs.AsQueryable();

            if (filter.ActionType.HasValue)
                query = query.Where(a => a.ActionType == filter.ActionType);

            if (!string.IsNullOrWhiteSpace(filter.EntityType))
                query = query.Where(a => a.EntityType == filter.EntityType);

            if (!string.IsNullOrWhiteSpace(filter.EntityId))
                query = query.Where(a => a.EntityId == filter.EntityId);

            if (filter.From.HasValue)
                query = query.Where(a => a.TimestampUtc >= filter.From);

            if (filter.To.HasValue)
                query = query.Where(a => a.TimestampUtc <= filter.To);

            var logs = await query
                .OrderByDescending(a => a.TimestampUtc)
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return Ok(logs);
        }

        [Authorize(Roles = "Executive,Regulator")]
        [HttpPost("audit-logs/export/csv")]
        public async Task<IActionResult> ExportAuditLogsCsv([FromBody] AuditLogFilter filter)
        {
            var logs = await QueryAuditLogs(filter).ToListAsync();

            var sb = new StringBuilder();
            sb.AppendLine("TimestampUtc,UserName,ActionType,EntityType,EntityId,Summary");

            foreach (var log in logs)
            {
                sb.AppendLine($"{log.TimestampUtc:o}," +
                              $"\"{log.UserName}\"," +
                              $"{log.ActionType}," +
                              $"\"{log.EntityType}\"," +
                              $"\"{log.EntityId}\"," +
                              $"\"{log.Summary}\"");
            }

            var bytes = Encoding.UTF8.GetBytes(sb.ToString());
            return File(bytes, "text/csv", "audit-logs.csv");
        }

        [Authorize(Roles = "Executive,Regulator")]
        [HttpPost("audit-logs/export/pdf")]
        public async Task<IActionResult> ExportAuditLogsPdf([FromBody] AuditLogFilter filter,
            [FromServices] IAuditPdfExporter exporter)
        {
            var logs = await QueryAuditLogs(filter).ToListAsync();
            var pdf = exporter.Export(logs);
            return File(pdf, "application/pdf", "audit-logs.pdf");
        }

        private IQueryable<AuditLog> QueryAuditLogs(AuditLogFilter filter)
        {
            var query = _db.AuditLogs.AsQueryable();

            if (filter.ActionType.HasValue)
                query = query.Where(a => a.ActionType == filter.ActionType);

            if (!string.IsNullOrWhiteSpace(filter.EntityType))
                query = query.Where(a => a.EntityType == filter.EntityType);

            if (!string.IsNullOrWhiteSpace(filter.EntityId))
                query = query.Where(a => a.EntityId == filter.EntityId);

            if (filter.From.HasValue)
                query = query.Where(a => a.TimestampUtc >= filter.From);

            if (filter.To.HasValue)
                query = query.Where(a => a.TimestampUtc <= filter.To);

            return query.OrderByDescending(a => a.TimestampUtc);
        }
    }
}
