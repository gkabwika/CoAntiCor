using Azure;
using Microsoft.EntityFrameworkCore;
using CoAntiCor.Core.Interfaces;
using CoAntiCor.Infrastructure.Context;
using System.Threading;

namespace CoAntiCor.API.Services
{
    /// <summary>
    /// TenantAwareRepository base class (all repos inherit tenant filtering)
    /// Assuming:
    /// - ITenantContext with BrokerOfficeId, ProvinceCode
    /// - Entities implementing ITenantScoped and/or IProvinceScoped
    /// - Global filters already in DbContext(as we did earlier)
    /// We’ll still centralize tenant‑aware operations.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class TenantAwareRepository<TEntity> : ITenantAwareRepository<TEntity>
      where TEntity : class
    {
        protected readonly ApplicationDbContext _db;
        protected readonly ITenantContext _tenant;

        protected TenantAwareRepository(ApplicationDbContext db, ITenantContext tenant)
        {
            _db = db;
            _tenant = tenant;
        }

        protected IQueryable<TEntity> Query => _db.Set<TEntity>();

        public virtual async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            // Assuming entities have Id = Guid
            return await Query.FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id, ct);
        }

        public virtual Task<List<TEntity>> ListAsync(CancellationToken ct = default)
            => Query.ToListAsync(ct); // already tenant‑filtered by global filters

        public virtual async Task AddAsync(TEntity entity, CancellationToken ct = default)
        {
            // If tenant‑scoped, stamp tenant
            if (entity is ITenantScoped ts && _tenant.BrokerOfficeId.HasValue)
                ts.BrokerOfficeId = _tenant.BrokerOfficeId.Value;

            if (entity is IProvinceScoped ps && _tenant.ProvinceCode is not null)
                ps.ProvinceCode = _tenant.ProvinceCode;

            await _db.Set<TEntity>().AddAsync(entity, ct);
        }

        public Task SaveChangesAsync(CancellationToken ct = default)
            => _db.SaveChangesAsync(ct);
    }
}
