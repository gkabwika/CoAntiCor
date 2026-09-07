using CoAntiCor.Core.Domain.ServiceRequest;
using CoAntiCor.Core.DTO.Incident;
using CoAntiCor.Core.Enums;
using CoAntiCor.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoAntiCor.Core.Domain;
using CoAntiCor.Infrastructure;

namespace CoAntiCor.API.V1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncidentRequestsController : ControllerBase
{
    private readonly CoAntiCorDbContext _db;
    private readonly ILogger<IncidentRequestsController> _logger;

    public IncidentRequestsController(CoAntiCorDbContext db, ILogger<IncidentRequestsController> logger)
    {
        _db = db;
        _logger = logger;
    }

    // POST api/incidentrequests
    [HttpPost]
    public async Task<ActionResult<IncidentRequest>> Create([FromBody] CreateIncidentRequestDto dto)
    {
        var incident = new IncidentRequest
        {
            Id = Guid.NewGuid(),
            IncidentNumber = GenerateIncidentNumber(),
            Title = dto.Title,
            Description = dto.Description,
            IncidentTypeOther = dto.IncidentType,
            Category = dto.Category,
            Province = dto.Province,
            City = dto.City,
            IsAnonymous = dto.IsAnonymous,
            CitizenName = dto.IsAnonymous ? null : dto.CitizenName,
            CitizenEmail = dto.IsAnonymous ? null : dto.CitizenEmail,
            CitizenPhone = dto.IsAnonymous ? null : dto.CitizenPhone,
            Status = IncidentStatus.Submitted,
            CreatedAt = DateTime.UtcNow,
            SubmittedAt = DateTime.UtcNow,
            LastUpdatedAt = DateTime.UtcNow
        };

        _db.IncidentRequests.Add(incident);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = incident.Id }, incident);
    }

    // GET api/incidentrequests/{id}
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<IncidentRequest>> GetById(Guid id)
    {
        var incident = await _db.IncidentRequests
            .Include(i => i.EvidenceFiles)
            .Include(i => i.PhaseHistory)
            .FirstOrDefaultAsync(i => i.Id == id);

        if (incident is null)
            return NotFound();

        return incident;
    }

    // GET api/incidentrequests/search
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<IncidentRequest>>> Search([FromQuery] SearchIncidentRequestDto dto)
    {
        var query = _db.IncidentRequests.AsQueryable();

        if (!string.IsNullOrWhiteSpace(dto.Query))
        {
            query = query.Where(i =>
                EF.Functions.Like(i.Title, $"%{dto.Query}%") ||
                EF.Functions.Like(i.Description, $"%{dto.Query}%"));
        }

        if (!string.IsNullOrWhiteSpace(dto.IncidentType))
            query = query.Where(i => i.IncidentType!.ToString() == dto.IncidentType);

        if (!string.IsNullOrWhiteSpace(dto.Province))
            query = query.Where(i => i.Province == dto.Province);

        if (!string.IsNullOrWhiteSpace(dto.Category))
            query = query.Where(i => i.Category == dto.Category);

        var results = await query
            .OrderByDescending(i => i.CreatedAt)
            .Take(20)
            .ToListAsync();

        return results;
    }

    // POST api/incidentrequests/{id}/evidence
    [HttpPost("{id:guid}/evidence")]
    [RequestSizeLimit(50_000_000)] // 50 MB example
    public async Task<ActionResult> UploadEvidence(Guid id, [FromForm] IncidentEvidenceUploadDto dto)
    {
        var incident = await _db.IncidentRequests.FindAsync(id);
        if (incident is null)
            return NotFound();

        if (dto.File is null || dto.File.Length == 0)
            return BadRequest("File is required.");

        // TODO: store file in blob / disk; here we just simulate a path
        var storagePath = $"incidents/{id}/{Guid.NewGuid()}_{dto.File.FileName}";

        // You would actually save the file to disk or cloud here.

        var evidence = new IncidentEvidence
        {
            Id = Guid.NewGuid(),
            IncidentRequestId = id,
            FileName = dto.File.FileName,
            ContentType = dto.File.ContentType,
            SizeBytes = dto.File.Length,
            StoragePath = storagePath,
            UploadedAt = DateTime.UtcNow
        };

        _db.IncidentEvidence.Add(evidence);
        await _db.SaveChangesAsync();

        return Ok();
    }

    private string GenerateIncidentNumber()
    {
        // Example: COA-2026-000001
        var datePart = DateTime.UtcNow.ToString("yyyyMMdd");
        var randomPart = Guid.NewGuid().ToString("N")[..6].ToUpperInvariant();
        return $"COA-{datePart}-{randomPart}";
    }
}
