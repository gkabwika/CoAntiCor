using CoAntiCor.Core.Interfaces;
using CoAntiCor.Infrastructure.Context;

namespace CoAntiCor.API.Services
{
    public sealed class ListingRepository : TenantAwareRepository<Listing>, IListingRepository
    {
        public ListingRepository(ApplicationDbContext db, ITenantContext tenant)
            : base(db, tenant) { }

        Task ITenantAwareRepository<Core.Services.Listing>.AddAsync(Core.Services.Listing entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        Task<Core.Services.Listing?> ITenantAwareRepository<Core.Services.Listing>.GetByIdAsync(Guid id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        Task<List<Core.Services.Listing>> ITenantAwareRepository<Core.Services.Listing>.ListAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        Task ITenantAwareRepository<Core.Services.Listing>.SaveChangesAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }

}
