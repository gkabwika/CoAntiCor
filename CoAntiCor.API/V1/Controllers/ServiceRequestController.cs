using Azure.Core;
using CoAntiCor.Core.Domain.ServiceRequest;
using CoAntiCor.Core.DTO;
using CoAntiCor.Core.DTO.Incident;
using CoAntiCor.Core.Interfaces;
using CoAntiCor.Core.Model;
using CoAntiCor.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CoAntiCor.API.V1.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ServiceRequestController : ControllerBase
{
    private readonly IComplaintService _service;
    private readonly CoAntiCorDbContext _db;
    public ServiceRequestController(IComplaintService service, CoAntiCorDbContext db)
    {
        _service = service;
        _db = db;
    }


    // POST /api/v1/ServiceRequest/Searchv2
    [HttpPost("Searchv2")]
    public async Task<ActionResult<List<ComplaintDetailDto>>> SearchV2([FromBody] SearchRequestDto request)
    {
        //var results = await _search.SearchAsync((Guid)_tenant.TenantId, request.Term, request.MaxResults);

        var results = _db.Complaints
            .Where(c => c.Title.Contains(request.Term, StringComparison.OrdinalIgnoreCase))
            .Take((int)request.MaxResults)
            .ToList();

        return Ok(results);
    }



    // POST /api/v1/ServiceRequest/AI/Search
    [HttpPost("Search")]
    public async Task<ActionResult<List<ComplaintDetailDto>>> Search([FromBody] SearchRequestDto dto)
    {
        var results = await _service.SearchAsync(dto.Term,1000);
        return Ok(results);
    }
    /// <summary>
    /// Added Take(max) to restrict results to at most 1000. Filtering is performed in SQL (StringComparison isn't translatable)
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    // POST /api/v1/ServiceRequest/AI/SearchIncident
    [HttpPost("SearchIncident")]
    public async Task<ActionResult<List<IncidentRequestDto>>> SearchIncident([FromBody] SearchRequestDto request)
    {

        // limit to top 1000 (or request.MaxResults if provided and <= 1000)
        var max = (request.MaxResults.HasValue) ? Math.Min(request.MaxResults.Value, 1000) : 1000;

        // Use EF.Functions.Like so filtering is performed in SQL (StringComparison isn't translatable)
        var query = await _db.IncidentRequests
            .Where(c => EF.Functions.Like(c.Title, $"%{request.Term}%") || EF.Functions.Like(c.Description, $"%{request.Term}%"))
            .Take(max)
            .ToListAsync();

       
        //query = query.Where(x => x.Category == request.Term
        //    || x.Province == request.Term || x.IncidentType!.NameFrench == request.Term);

        var results = query
            .Select(x => new IncidentRequestDto
            {
                Id = x.Id,
                IncidentNumber = x.IncidentNumber,
                Title = x.Title,
                Description = x.Description,
                IncidentType = x.IncidentType != null ? x.IncidentType.Name : string.Empty,
                Category = x.Category,
                Province = x.Province,
                City = x.City,
                IsAnonymous = x.IsAnonymous,
                CitizenName = x.CitizenName,
                CitizenEmail = x.CitizenEmail,
                CitizenPhone = x.CitizenPhone,
                Status = x.Status,
                CreatedAt = x.CreatedAt,
                SubmittedAt = x.SubmittedAt,
                IncidentCategory = x.IncidentCategory != null ? x.IncidentCategory.Name : string.Empty,
                ReporterName = x.ReporterFullName,
                Attachments = new List<AttachmentDto>(), // Populate as needed
                History = new List<HistoryDto>(), // Populate as needed
                Phases = new List<ProcessingPhaseDto>() // Populate as needed
            })
            .ToList();

        return Ok(results);
    }


    [HttpGet("searchadvance")]
    public async Task<ActionResult<PagedResult<IncidentRequestDto>>> SearchAdvance(
    [FromQuery] string? province,
    [FromQuery] string? category,
    [FromQuery] string? period,
    [FromQuery] int page = 1,
    [FromQuery] int pageSize = 20)
    {
        var query = _db.IncidentRequests.AsQueryable();

        if (!string.IsNullOrWhiteSpace(province))
            query = query.Where(x => x.Province == province);

        if (!string.IsNullOrWhiteSpace(category))
            query = query.Where(x => x.Category == category);

        if (!string.IsNullOrWhiteSpace(period))
            query = ApplyPeriodFilter(query, period);

        var total = await query.CountAsync();

        var items = await query
               .OrderByDescending(x => x.CreatedAt)
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .Select(x => new IncidentRequestDto
               {
                   Id = x.Id,
                   IncidentNumber = x.IncidentNumber,
                   Province = x.Province,
                   Category = x.Category,
                   IncidentType = x.IncidentType != null ? x.IncidentType.Name : string.Empty,
                   Status = x.Status,
                   CreatedAt = x.CreatedAt
               })
               .ToListAsync();

        return new PagedResult<IncidentRequestDto>(items, total, page, pageSize);
    }

    private IQueryable<IncidentRequest> ApplyPeriodFilter(IQueryable<IncidentRequest> query, string period)
    {
        // Example: filter by year or month, adjust as needed
        if (string.IsNullOrWhiteSpace(period))
            return query;

        if (period.Equals("last30days", StringComparison.OrdinalIgnoreCase))
        {
            var fromDate = DateTime.UtcNow.AddDays(-30);
            return query.Where(x => x.CreatedAt >= fromDate);
        }
        if (period.Equals("thisyear", StringComparison.OrdinalIgnoreCase))
        {
            var year = DateTime.UtcNow.Year;
            return query.Where(x => x.CreatedAt.Year == year);
        }
        // Add more period filters as needed

        return query;
    }

}

