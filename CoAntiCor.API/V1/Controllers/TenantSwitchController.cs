using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CoAntiCor.Core.Constant;
using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Interfaces;
using CoAntiCor.Core.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CoAntiCor.API.V1.Controllers
{
    /// <summary>
    /// TenantSwitch UI (for regulators to switch office/province)
    /// Concept:
    /// - Only users with regulator / admin roles can switch tenant context.
    /// - We store “impersonated” office/province in a cookie or in a special claim.
    /// - TenantMiddleware reads that override when present.
    /// Wire Tenant Switching into the Audit Log
    /// Every time a regulator switches:
    /// - Office
    /// - Province

    /// </summary>
    /// 
    [ApiController]
    [Route("api/v1/tenant-switch")]
    [Authorize(Roles = "Regulator,Executive")]
    public class TenantSwitchController : ControllerBase
    {
        private readonly ITenantContext _tenant;
        private readonly ITenantAuditService _audit;

        public TenantSwitchController(ITenantContext tenant, ITenantAuditService audit)
        {
            _tenant = tenant;
            _audit = audit;
        }

        [HttpPost("office")]
        public async Task<IActionResult> SwitchOffice([FromBody] Guid? brokerOfficeId)
        {
            var user = HttpContext.User;

            var allowedOffices = user.FindFirst(CustomClaimTypes.AllowedOffices)?.Value?
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(Guid.Parse)
                .ToHashSet() ?? new HashSet<Guid>();

            if (brokerOfficeId.HasValue && !allowedOffices.Contains(brokerOfficeId.Value))
                return Forbid("You are not allowed to impersonate this office.");

            var oldOffice = _tenant.BrokerOfficeId;

            if (brokerOfficeId.HasValue)
                Response.Cookies.Append("ImpersonatedOfficeId", brokerOfficeId.Value.ToString(), new CookieOptions { HttpOnly = true, IsEssential = true });
            else
                Response.Cookies.Delete("ImpersonatedOfficeId");

            await _audit.LogAsync(new TenantAuditEntry
            {
                UserId = _tenant.UserId,
                BrokerOfficeId = oldOffice,
                ProvinceCode = _tenant.ProvinceCode,
                IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString(),
                ActionName = "SwitchOffice",
                EntityName = "TenantContext",
                DetailsJson = $"{{\"oldOffice\":\"{oldOffice}\",\"newOffice\":\"{brokerOfficeId}\"}}"
            });

            return Ok();
        }

        [HttpPost("province")]
        public async Task<IActionResult> SwitchProvince([FromBody] string? provinceCode)
        {
            var user = HttpContext.User;

            var allowedProvinces = user.FindFirst(CustomClaimTypes.AllowedProvinces)?.Value?
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .ToHashSet() ?? new HashSet<string>();

            if (!string.IsNullOrWhiteSpace(provinceCode) && !allowedProvinces.Contains(provinceCode))
                return Forbid("You are not allowed to impersonate this province.");

            var oldProvince = _tenant.ProvinceCode;

            if (!string.IsNullOrWhiteSpace(provinceCode))
                Response.Cookies.Append("ImpersonatedProvince", provinceCode, new CookieOptions { HttpOnly = true, IsEssential = true });
            else
                Response.Cookies.Delete("ImpersonatedProvince");

            await _audit.LogAsync(new TenantAuditEntry
            {
                UserId = _tenant.UserId,
                BrokerOfficeId = _tenant.BrokerOfficeId,
                ProvinceCode = oldProvince,
                IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString(),
                ActionName = "SwitchProvince",
                EntityName = "TenantContext",
                DetailsJson = $"{{\"oldProvince\":\"{oldProvince}\",\"newProvince\":\"{provinceCode}\"}}"
            });

            return Ok();
        }
    }
}