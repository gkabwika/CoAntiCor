using CoAntiCor.API.Services.Interface;
using CoAntiCor.Core.Domain.ServiceRequest;
using CoAntiCor.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace CoAntiCor.API.V1.Controllers
{
    [ApiController]
    [Route("api/v1/admin/security")]
    public class IncidentSecurityController : ControllerBase
    {
        private readonly CoAntiCorDbContext _db;
        private readonly IIncidentSecurityRiskService _riskService;

        public IncidentSecurityController(CoAntiCorDbContext db, IIncidentSecurityRiskService riskService)
        {
            _db = db;
            _riskService = riskService;
        }

        [HttpGet("{incidentRequestId:guid}")]
        public async Task<ActionResult<IncidentSecurityDetail>> Get(Guid incidentRequestId)
        {
            var detail = await _db.IncidentSecurityDetails
                .FirstOrDefaultAsync(x => x.IncidentRequestId == incidentRequestId);

            if (detail == null) return NotFound();

            return Ok(detail);
        }

        [HttpGet("list")]
        public async Task<ActionResult<IncidentSecurityDetail>> GetList()
        {
            var detail = await _db.IncidentSecurityDetails
                .ToListAsync();

            if (detail == null) return NotFound();

            return Ok(detail);
        }

        [HttpPost("{incidentRequestId:guid}")]
        public async Task<ActionResult> Upsert(Guid incidentRequestId, [FromBody] IncidentSecurityDetail dto)
        {
            var existing = await _db.IncidentSecurityDetails
                .FirstOrDefaultAsync(x => x.IncidentRequestId == incidentRequestId);

            if (existing == null)
            {
                dto.Id = Guid.NewGuid();
                dto.IncidentRequestId = incidentRequestId;
                _riskService.ComputeRisk(dto);
                _db.IncidentSecurityDetails.Add(dto);
            }
            else
            {
                // Map fields (or use AutoMapper)
                existing.DeviceId = dto.DeviceId;
                existing.DeviceModel = dto.DeviceModel;
                existing.DeviceManufacturer = dto.DeviceManufacturer;
                existing.DeviceOS = dto.DeviceOS;
                existing.DeviceOSVersion = dto.DeviceOSVersion;
                existing.BrowserName = dto.BrowserName;
                existing.BrowserVersion = dto.BrowserVersion;
                existing.UserAgentString = dto.UserAgentString;
                existing.ScreenResolution = dto.ScreenResolution;
                existing.IsMobileDevice = dto.IsMobileDevice;
                existing.IsBotSuspected = dto.IsBotSuspected;

                existing.IpAddress = dto.IpAddress;
                existing.IpAddressOriginCountry = dto.IpAddressOriginCountry;
                existing.IpAddressOriginCity = dto.IpAddressOriginCity;
                existing.IpAddressOriginISP = dto.IpAddressOriginISP;
                existing.VpnDetected = dto.VpnDetected;
                existing.ProxyDetected = dto.ProxyDetected;
                existing.TorDetected = dto.TorDetected;
                existing.HostingProviderDetected = dto.HostingProviderDetected;
                existing.NetworkType = dto.NetworkType;

                existing.GeoLatitude = dto.GeoLatitude;
                existing.GeoLongitude = dto.GeoLongitude;
                existing.GeoAccuracyMeters = dto.GeoAccuracyMeters;
                existing.GeoCountry = dto.GeoCountry;
                existing.GeoCity = dto.GeoCity;
                existing.GeoRegion = dto.GeoRegion;

                existing.TypingSpeedWPM = dto.TypingSpeedWPM;
                existing.MouseMovementPatternHash = dto.MouseMovementPatternHash;
                existing.TouchPressurePatternHash = dto.TouchPressurePatternHash;
                existing.InteractionIntervalMs = dto.InteractionIntervalMs;
                existing.SuspiciousInteractionScore = dto.SuspiciousInteractionScore;

                existing.FirstAccessedAtUtc = dto.FirstAccessedAtUtc;
                existing.LastAccessedAtUtc = dto.LastAccessedAtUtc;
                existing.SubmissionAttemptCount = dto.SubmissionAttemptCount;
                existing.SubmissionCompletedAtUtc = dto.SubmissionCompletedAtUtc;
                existing.SessionDurationSeconds = dto.SessionDurationSeconds;
                existing.SessionId = dto.SessionId;
                existing.SessionReused = dto.SessionReused;

                existing.RepeatedSubmissionDetected = dto.RepeatedSubmissionDetected;
                existing.DuplicateContentDetected = dto.DuplicateContentDetected;
                existing.HighRiskPatternDetected = dto.HighRiskPatternDetected;
                existing.BlacklistHit = dto.BlacklistHit;
                existing.WhitelistHit = dto.WhitelistHit;

                existing.JavascriptEnabled = dto.JavascriptEnabled;
                existing.CookiesEnabled = dto.CookiesEnabled;
                existing.LocalStorageEnabled = dto.LocalStorageEnabled;
                existing.TimezoneOffset = dto.TimezoneOffset;
                existing.Language = dto.Language;
                existing.Platform = dto.Platform;
                existing.ReferrerUrl = dto.ReferrerUrl;
                existing.EntryUrl = dto.EntryUrl;

                _riskService.ComputeRisk(existing);
            }

            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("risk/{incidentRequestId:guid}")]
        public async Task<ActionResult<object>> GetRisk(Guid incidentRequestId)
        {
            var detail = await _db.IncidentSecurityDetails
                .FirstOrDefaultAsync(x => x.IncidentRequestId == incidentRequestId);

            if (detail == null) return NotFound();

            return Ok(new
            {
                detail.RiskScore,
                detail.RiskLevel,
                detail.RepeatedSubmissionDetected,
                detail.DuplicateContentDetected,
                detail.HighRiskPatternDetected,
                detail.BlacklistHit,
                detail.WhitelistHit
            });
        }
    }

}
