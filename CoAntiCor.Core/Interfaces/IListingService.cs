
using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Enums;

namespace CoAntiCor.Core.Interfaces
{

    public interface IListingService
    {
        Task<Guid> CreateListingAsync(CreateListingRequest request, Guid userId);
        Task ChangeStatusAsync(Guid listingId, ListingStatus newStatus, Guid userId);
    }
}
