using CoAntiCor.Core.DTO;
using CoAntiCor.Core.Interfaces;
using CoAntiCor.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CoAntiCor.API.V1.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class LookupsController : ControllerBase
{
    private readonly IComplaintService _service;
    private readonly CoAntiCorDbContext _db;
    public LookupsController(IComplaintService service, CoAntiCorDbContext db)
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

    [HttpGet("IncidentCategories")]
    public async Task<ActionResult<List<IncidentCategoryDto>>> IncidentCategories()
    {
        var results = await _db.IncidentCategories
        .Where(c => c.NameFrench.Length > 0)
        .ToListAsync();

        return Ok(results);
    }

    [HttpGet("IncidentTypes")]
    public async Task<ActionResult<List<IncidentTypeDto>>> IncidentTypes()
    {
     
        var results = await _db.IncidentTypes
            .Where(c => c.NameFrench.Length > 0)
            .ToListAsync();

        return Ok(results);
    }
    [HttpGet("Provinces")]
    public async Task<ActionResult<List<ProvinceDto>>> Provinces()
    {

        var results = await _db.Provinces
            .Where(c => c.NameFrench.Length > 0)
            .ToListAsync();

        return Ok(results);
    }
    [HttpGet("GovernmentOffices")]
    public async Task<ActionResult<List<GovernmentOfficeDto>>> GovernmentOffices()
    {

        var results = await _db.GovernmentOffices
            .Where(c => c.Name.Length > 0)
            .ToListAsync();

        return Ok(results);
    }
}

