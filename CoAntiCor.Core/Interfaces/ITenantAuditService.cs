using CoAntiCor.Core.Domain;

namespace CoAntiCor.Core.Interfaces
{
    public interface ITenantAuditService
    {
        Task LogAsync(TenantAuditEntry entry, CancellationToken ct = default);
    }
}
