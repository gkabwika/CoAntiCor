using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using CoAntiCor.API.Services;
using CoAntiCor.Core.Domain;
using CoAntiCor.Core.DTO;
using CoAntiCor.Core.Interfaces;
using CoAntiCor.Core.Model;
using CoAntiCor.Core.Services;
using CoAntiCor.Infrastructure.Context;
using System.Text.Json;


namespace CoAntiCor.API.V1.Controllers;


[ApiController]
[Route("api/v1/listings")]
[TenantScope(requireTenant: true)]
[TenantAudit("Listing")]
public class ListingsController : ControllerBase
{
    /// <summary>
    /// SearchController (LLM‑powered)
    /// </summary>

    private readonly ITenantContext _tenant;
    private readonly CoAntiCorDbContext _db;
    private readonly ILogger<ListingsController> _logger;


    public ListingsController(ITenantContext tenant,
        CoAntiCorDbContext db, ILogger<ListingsController> logger)
    {
        _tenant = tenant;
        _db = db;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get() => Ok(/* auto‑filtered via EF */);


    
}







