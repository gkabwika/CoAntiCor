
namespace CoAntiCor.Core.Domain
{
    public sealed class CreateListingRequest : EntityBaseObject
    {
        public Guid PropertyId { get; init; }
        public string ListingType { get; init; } = default!;   // e.g. "Sale" or "Rent"
        public decimal Price { get; init; }
        public string Currency { get; init; } = "USD";
        public string? Notes { get; init; }
    }
}
