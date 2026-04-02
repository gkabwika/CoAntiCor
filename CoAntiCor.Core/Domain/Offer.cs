using CoAntiCor.Core.Enums;
using CoAntiCor.Core.Domain.Payment;

namespace CoAntiCor.Core.Domain
{
    public class Offer : EntityBaseObject
    {
        public Guid PropertyId { get; set; }
        public Contract? Contract { get; set; }
        //public Property Property { get; set; } = default!;
        public ListingType ListingType { get; set; }
        public Guid BuyerPartyId { get; set; }
        public decimal OfferedPrice { get; set; }        
        public string BuyerName { get; set; } = default!;
        public string SellerName { get; set; } = default!;
        public string Currency { get; set; } = "USD";
        public DateOnly? MoveInDate { get; set; }
        public OfferStatus Status { get; set; } = OfferStatus.Draft;
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public Guid CreatedByUserId { get; set; }
        public ICollection<Payment.Payment> Payments { get; set; } = new List<Payment.Payment>();
    }
}
