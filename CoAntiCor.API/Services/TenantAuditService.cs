using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Interfaces;
using CoAntiCor.Infrastructure.Context;

namespace CoAntiCor.API.Services
{
    /// <summary>
    /// TenantAudit system (logs Tenant, Province, User, Office, IP, Action, Entity)
    /// </summary>
    public sealed class TenantAuditService : ITenantAuditService
    {
        private readonly CoAntiCorDbContext _db;

        public TenantAuditService(CoAntiCorDbContext db)
        {
            _db = db;
        }

        public async Task LogAsync(TenantAuditEntry entry, CancellationToken ct = default)
        {
            await _db.Set<TenantAuditEntry>().AddAsync(entry, ct);
            await _db.SaveChangesAsync(ct);
        }
    }
}
