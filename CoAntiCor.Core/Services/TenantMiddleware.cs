using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Interfaces;
using QuestPDF.Infrastructure;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;


namespace CoAntiCor.Core.Services;
/// <summary>
///  NEW TenantMiddleware (clean, safe, no UserManager)
/// </summary>
public class TenantMiddleware
{
    private readonly RequestDelegate _next;

    public TenantMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    private readonly Dictionary<string, string> _subdomainProvinceMap = new()
    {
        { "kinshasa", "KIN" },
        { "lubumbashi", "LUB" },
        // Add more mappings as needed
    };

    private List<Claim> SetClaims(HttpContext context, User user, string role)    
    {
        List < Claim > myclaims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, role)
        };
  
        //// Add roles
        //var roles = await _userManager.GetRolesAsync(user);
        //myclaims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

        //// Add allowed offices (comma-separated)
        //if (allowedOffices.Any())
        //{
        //    myclaims.Add(new Claim("allowedOffices", string.Join(",", allowedOffices)));
        //}

        //// Add allowed provinces (comma-separated)
        //if (allowedProvinces.Any())
        //{
        //    myclaims.Add(new Claim("allowedProvinces", string.Join(",", allowedProvinces)));
        //}

        return myclaims;
    }

    private readonly Dictionary<string, string> _roleMapping = new()
    {
        { "Broker", "Broker" },
        { "Regulator", "Regulator" },
        { "Executive", "Executive" }
    };
    public async Task InvokeAsync(HttpContext context, ITenantContext tenant)
    {
        var tc = (TenantContext)tenant;

        // 1. Extract UserId from JWT
        var userId = context.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        if (Guid.TryParse(userId, out var guid))
            tc.UserId = guid;

        // 2. Extract BrokerOfficeId from JWT (custom claim)
        //var officeId = context.User.FindFirst("brokerOfficeId")?.Value;
        var officeId = context.User?.FindFirst("brokerOfficeId")?.Value;
        if (Guid.TryParse(officeId, out var officeGuid))
            tc.BrokerOfficeId = officeGuid;

        // 3. Extract roles
        //var roles = context.User.Claims
        //    .Where(c => c.Type == ClaimTypes.Role)
        //    .Select(c => c.Value)
        //    .ToList();
        var roles = context.User?.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => c.Value)
            .ToList() ?? new List<string>();

        tc.Roles = roles;

        //Where to add the new claims
       // User? user = (User)context.User!;

        //var myClaims = SetClaims(context, user, roles![0]);

        // 4. Subdomain → province mapping
        var host = context.Request.Host.Host;

        if (host.StartsWith("kinshasa.", StringComparison.OrdinalIgnoreCase))
            tc.ProvinceCode = "KIN";

        if (host.StartsWith("lubumbashi.", StringComparison.OrdinalIgnoreCase))
            tc.ProvinceCode = "LUB";

        // Impersonation for regulators
        if (tc.IsRegulator)
        {
            if (context.Request.Cookies.TryGetValue("ImpersonatedOfficeId", out var impOffice)
                && Guid.TryParse(impOffice, out var impOfficeGuid))
            {
                tc.BrokerOfficeId = impOfficeGuid;
            }

            if (context.Request.Cookies.TryGetValue("ImpersonatedProvince", out var impProvince)
                && !string.IsNullOrWhiteSpace(impProvince))
            {
                tc.ProvinceCode = impProvince;
            }
        }

        // 5. Continue pipeline
        await _next(context);
    }
}
