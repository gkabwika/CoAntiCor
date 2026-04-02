using CoAntiCor.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using CoAntiCor.Core.Enums;
using System.Reflection;
using CoAntiCor.Core.Domain;

namespace CoAntiCor.API.Services
{
    /// <summary>
    /// Multi‑tenant role enforcement example
    /// </summary>
    public class ListingService : IListingService
    {
        private readonly ITenantContext _tenant;

        public ListingService(ITenantContext tenant)
        {
            _tenant = tenant;
        }

        //Now you can enforce roles anywhere:
        //Ensures the user belongs to a specific office or any office, depending on your requirements.
        [Authorize(Policy = "RequireBrokerOffice")]
        public Task<Guid> CreateListingAsync(CreateListingRequest req, Guid userId)
        {
            if (!_tenant.Roles.Contains("Broker"))
                throw new UnauthorizedAccessException("Only brokers can create listings.");

            //Or enforce office‑scoping
            //if (listing.BrokerOfficeId != _tenant.BrokerOfficeId)
            //    throw new UnauthorizedAccessException("Cross-office access denied.");
            // ...
            return Task.FromResult(Guid.NewGuid());
        }

        //Ensures the user belongs to a specific office or any office, depending on your requirements.
        [Authorize(Policy = "RequireBrokerOffice")]
        Task IListingService.ChangeStatusAsync(Guid listingId, ListingStatus newStatus, Guid userId)
        {
            throw new NotImplementedException();
        }

        Task<Guid> IListingService.CreateListingAsync(CreateListingRequest request, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
