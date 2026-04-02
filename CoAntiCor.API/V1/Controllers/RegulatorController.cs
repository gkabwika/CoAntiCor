using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoAntiCor.API.Services;
using CoAntiCor.Core.Domain;
using CoAntiCor.Core.DTO;
using CoAntiCor.Core.Interfaces;
using CoAntiCor.Infrastructure.Context;

namespace CoAntiCor.API.V1.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize(Roles = "Regulator,Admin")]
public class RegulatorController : ControllerBase
{
    private readonly ICaseFilePdfService _caseFile;
    private readonly CoAntiCorDbContext _db;
    private readonly ILogger<RegulatorController> _logger;


    public RegulatorController(ICaseFilePdfService caseFile, CoAntiCorDbContext db, ILogger<RegulatorController> logger)
    {
        _db = db; 
        _caseFile = caseFile;
        _logger = logger;
    }

    // ------------------------------------------------------------
    // GET: api/v1/regulator/summary
    // ------------------------------------------------------------
    [HttpGet("summary")]
    public async Task<ActionResult<RegulatorSummaryDto>> Summary()
    {
      return Ok();
    }

    [HttpGet("casefile/{offerId:guid}")]
    public async Task<IActionResult> CaseFile(Guid offerId)
    {
        var bundle = await _caseFile.GenerateAsync(offerId, _db,
            HttpContext.RequestServices.GetRequiredService<IContractPdfService>());

        return File(bundle.PdfBytes, "application/pdf", bundle.FileName);
    }

    [HttpPost("audit/search")]
    public async Task<ActionResult<List<AuditSearchResultDto>>> SearchAudit([FromBody] AuditSearchRequest req)
    {
        var q = _db.SignatureAudits
            .Include(a => a.Contract)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(req.UserId))
            q = q.Where(a => a.ActorUserId == req.UserId);

        if (!string.IsNullOrWhiteSpace(req.ContractNumber))
            q = q.Where(a => a.Contract.ContractNumber == req.ContractNumber);

        if (!string.IsNullOrWhiteSpace(req.Action))
            q = q.Where(a => a.Action == req.Action);

        if (req.FromUtc.HasValue)
            q = q.Where(a => a.OccurredAtUtc >= req.FromUtc.Value);
        if (req.ToUtc.HasValue)
            q = q.Where(a => a.OccurredAtUtc <= req.ToUtc.Value);

        var list = await q
            .OrderByDescending(a => a.OccurredAtUtc)
            .Take(500)
            .Select(a => new AuditSearchResultDto(
                a.ContractId,
                a.Contract.ContractNumber,
                a.ActorUserId,
                a.ActorRole,
                a.Action,
                a.OccurredAtUtc,
                a.IpAddress))
            .ToListAsync();

        return Ok(list);
    }
}


