using CoAntiCor.Core.Enums;
using CoAntiCor.Core.Domain.Payment;

namespace CoAntiCor.Core.Domain
{
    public class Contract : EntityBaseObject
    {
        public Guid OfferId { get; set; }
        public Offer Offer { get; set; } = default!;

        public string ContractNumber { get; set; } = default!;
        public string HtmlBody { get; set; } = default!;
        public ContractStatus Status { get; set; } = ContractStatus.Draft;

        public string? BuyerSignature { get; set; }
        public DateTime? BuyerSignedAtUtc { get; set; }

        public string? SellerSignature { get; set; }
        public DateTime? SellerSignedAtUtc { get; set; }

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    }

}
