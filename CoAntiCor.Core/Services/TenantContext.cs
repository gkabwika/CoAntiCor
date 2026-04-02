
using CoAntiCor.Core.Interfaces;


namespace CoAntiCor.Core.Services;

/// <summary>
/// TenantSwitch UI (for regulators to switch office/province)
/// Concept:
/// - Only users with regulator / admin roles can switch tenant context.
/// - We store “impersonated” office/province in a cookie or in a special claim.
/// - TenantMiddleware reads that override when present.
/// </summary>
public class TenantContext : ITenantContext
{
    public Guid? BrokerOfficeId { get; internal set; }
    public string? ProvinceCode { get; internal set; }
    public Guid? UserId { get; internal set; }
    public  string? UserName { get; internal set; }
    public IReadOnlyList<string> Roles { get; internal set; } = Array.Empty<string>();
    public bool IsRegulator =>
       Roles.Contains("Regulator") || Roles.Contains("Executive");
}
