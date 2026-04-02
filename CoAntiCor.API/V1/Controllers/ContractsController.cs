using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CoAntiCor.API.Services;
using CoAntiCor.Core.Domain;
using CoAntiCor.Core.DTO;
using CoAntiCor.Core.Enums;
using CoAntiCor.Core.Interfaces;
using CoAntiCor.Core.Services;
using CoAntiCor.Infrastructure.Context;
using System;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
using static System.Net.Mime.MediaTypeNames;

namespace CoAntiCor.API.V1.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]

public class ContractsController : ControllerBase
{
    /// <summary>
    /// - A full signature audit trail suitable for legal/regulator review
    /// /// If you want, next step could be: hashing PDF + signatures to a tamper‑evident log(e.g., append‑only table or external ledger).
    /// </summary>
    private readonly CoAntiCorDbContext _db;
    private readonly IContractPdfService _pdfService;
    private readonly IContractService _contractService;
    private readonly ICaseFilePdfService _caseFileService;

    private readonly ILogger<ContractsController> _logger;


    public ContractsController(
        IContractPdfService pdfService, IContractService contractService,
        ICaseFilePdfService caseFileService, CoAntiCorDbContext db,  ILogger<ContractsController> logger)
    {
        _contractService = contractService;
        _pdfService = pdfService;
        _db = db;
        _logger = logger;
        _caseFileService = caseFileService;
    }

    [HttpGet("contracts/{offerId:guid}/lifecycle")]
    public async Task<ActionResult<ContractLifecycleDto>> Lifecycle(Guid offerId)
    {
    

        return Ok(null);
    }

    [HttpPost("generate")]
    public async Task<ActionResult<ContractDto>> GenerateContract([FromBody] GenerateContractRequest req)
    {
        var offer = await _db.Contracts
            .Include(o => o.OfferId)
            .FirstOrDefaultAsync(o => o.Id == req.OfferId);

        if (offer is null)
            return NotFound();

        var number = $"CTR-{DateTime.UtcNow:yyyyMMdd}-{offer.Id.ToString()[..8]}";

        var html = $@"
            <h1>Contrat de vente / Sale Contract</h1>   
            <p>Date: {DateTime.UtcNow:yyyy-MM-dd}</p>
            ";

        var contract = new Contract
        {
            Id = Guid.NewGuid(),
            OfferId = offer.Id,
            ContractNumber = number,
            HtmlBody = html,
            Status = ContractStatus.PendingSignature
        };

        _db.Contracts.Add(contract);
        await _db.SaveChangesAsync();

        var dto = new ContractDto(
            contract.Id,
            contract.ContractNumber,
            contract.HtmlBody,
            contract.Status);

        return Ok(dto);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ContractDto>> Get(Guid id)
    {
        var contract = await _db.Contracts
            .Include(c => c.Offer)
            .Include(c => c.Offer.Contract)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (contract is null)
            return NotFound();

        var dto = new ContractDto(
            contract.Id,
            contract.ContractNumber,
            contract.HtmlBody,
            contract.Status
        );

        return Ok(dto);
    }

    [HttpGet("{id:guid}/pdf")]
    public async Task<IActionResult> Pdf(Guid id)
    {
        var contract = await _db.Contracts
            .Include(c => c.Offer)
            .Include(c => c.Offer.Contract)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (contract is null) return NotFound();

        var bytes = _pdfService.Generate(contract);
        return File(bytes, "application/pdf", $"{contract.ContractNumber}.pdf");
    }

    //[HttpPost("sign/buyer")]
    //public async Task<IActionResult> SignBuyer([FromBody] SignContractRequest req)
    //{
    //    await _contractService.SignBuyerAsync(req, HttpContext);
    //    return Ok();
    //}

    //[HttpPost("sign/seller")]
    //public async Task<IActionResult> SignSeller([FromBody] SignContractRequest req)
    //{
    //    await _contractService.SignSellerAsync(req, HttpContext);
    //    return Ok();
    //}

    // ------------------------------------------------------------
    // BUYER SIGNATURE
    // ------------------------------------------------------------
    [HttpPost("sign/buyer")]
    public async Task<IActionResult> SignBuyer([FromBody] SignContractRequest req)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var contract = await _db.Contracts
            .Include(c => c.Offer)
            .FirstOrDefaultAsync(c => c.Id == req.ContractId);

        if (contract is null)
            return NotFound();

        if (contract.Offer.CreatedByUserId.ToString() != userId)
            return Forbid();

        contract.BuyerSignature = req.Signature;
        contract.BuyerSignedAtUtc = DateTime.UtcNow;
        contract.Status = contract.SellerSignature != null
            ? ContractStatus.FullySigned
            : ContractStatus.SignedByBuyer;

        _db.SignatureAudits.Add(new SignatureAudit
        {
            Id = Guid.NewGuid(),
            ContractId = contract.Id,
            ActorUserId = userId!,
            ActorRole = "Buyer",
            Action = "BuyerSigned",
            OccurredAtUtc = DateTime.UtcNow,
            IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString(),
            UserAgent = HttpContext.Request.Headers.UserAgent.ToString()
        });

        await _db.SaveChangesAsync();
        return Ok();
    }

    // ------------------------------------------------------------
    // SELLER SIGNATURE
    // ------------------------------------------------------------
    [HttpPost("sign/seller")]
    [Authorize(Roles = "Seller,Broker,Admin")]
    public async Task<IActionResult> SignSeller([FromBody] SignContractRequest req)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var contract = await _db.Contracts
            .Include(c => c.Offer)
            .FirstOrDefaultAsync(c => c.Id == req.ContractId);

        if (contract is null)
            return NotFound();

        contract.SellerSignature = req.Signature;
        contract.SellerSignedAtUtc = DateTime.UtcNow;
        contract.Status = contract.BuyerSignature != null
            ? ContractStatus.FullySigned
            : ContractStatus.SignedBySeller;

        _db.SignatureAudits.Add(new SignatureAudit
        {
            Id = Guid.NewGuid(),
            ContractId = contract.Id,
            ActorUserId = userId!,
            ActorRole = "Seller",
            Action = "SellerSigned",
            OccurredAtUtc = DateTime.UtcNow,
            IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString(),
            UserAgent = HttpContext.Request.Headers.UserAgent.ToString()
        });

        await _db.SaveChangesAsync();
        return Ok();
    }

    // ------------------------------------------------------------
    // SIGNATURE AUDIT TRAIL
    // ------------------------------------------------------------
    [HttpGet("{id:guid}/audit")]
    [Authorize(Roles = "Regulator,Admin")]
    public async Task<ActionResult<List<SignatureAuditDto>>> GetAudit(Guid id)
    {
        var audits = await _db.SignatureAudits
            .Where(a => a.ContractId == id)
            .OrderBy(a => a.OccurredAtUtc)
            .Select(a => new SignatureAuditDto(
                a.ActorUserId,
                a.ActorRole,
                a.Action,
                a.OccurredAtUtc,
                a.IpAddress,
                a.UserAgent))
            .ToListAsync();

        return Ok(audits);
    }

    // ------------------------------------------------------------
    // VERIFY CONTRACT INTEGRITY
    // ------------------------------------------------------------
    [HttpGet("{id:guid}/verify")]
    [Authorize(Roles = "Regulator,Admin")]
    public async Task<ActionResult<bool>> Verify(Guid id)
    {
        var contract = await _db.Contracts
            .Include(c => c.Offer)
            .Include(c => c.Offer.Contract)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (contract is null)
            return NotFound();

        var log = await _db.IntegrityLogs
            .Where(l => l.ObjectType == "Contract" && l.ObjectId == id)
            .OrderByDescending(l => l.CreatedAtUtc)
            .FirstOrDefaultAsync();


        return Ok();
    }

    // ------------------------------------------------------------
    // CONTRACT LIFECYCLE (REGULATOR)
    // ------------------------------------------------------------
    [HttpGet("lifecycle/{offerId:guid}")]
    [Authorize(Roles = "Regulator,Admin")]
    public async Task<ActionResult<ContractLifecycleDto>> LifecycleNew(Guid offerId)
    {
    


        return Ok();
    }

    // ------------------------------------------------------------
    // AUDIT SEARCH (REGULATOR)
    // ------------------------------------------------------------
    [HttpPost("audit/search")]
    [Authorize(Roles = "Regulator,Admin")]
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


    // ------------------------------------------------------------
    // CASE FILE PDF (REGULATOR)
    // ------------------------------------------------------------
    [HttpGet("casefile/{offerId:guid}")]
    [Authorize(Roles = "Regulator,Admin")]
    public async Task<IActionResult> CaseFile(Guid offerId)
    {
        var bundle = await _caseFileService.GenerateAsync(
            offerId,
            _db,
            _pdfService);

        return File(bundle.PdfBytes, "application/pdf", bundle.FileName);
    }

    // --------------------------------------------------------------------
    // PDF DOWNLOAD
    // --------------------------------------------------------------------
    [HttpGet("{id:guid}/downloadpdf")]
    public async Task<IActionResult> DownloadPdf(Guid id)
    {
        var contract = await _db.Contracts
            .Include(c => c.Offer)
            .Include(c => c.Offer.Contract)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (contract is null)
            return NotFound();

        var bytes = _pdfService.Generate(contract);
        return File(bytes, "application/pdf", $"{contract.ContractNumber}.pdf");
    }

}





