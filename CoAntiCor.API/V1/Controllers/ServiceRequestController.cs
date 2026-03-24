using CoAntiCor.Core.DTO;
using CoAntiCor.Core.Interfaces;
using CoAntiCor.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;


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

}

