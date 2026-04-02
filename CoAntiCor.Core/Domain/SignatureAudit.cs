
namespace CoAntiCor.Core.Domain
{
    public class SignatureAudit : EntityBaseObject
    {
        public Guid ContractId { get; set; }
        public Contract Contract { get; set; } = default!;

        public string ActorUserId { get; set; } = default!;
        public string ActorRole { get; set; } = default!;
        public string Action { get; set; } = default!; // "BuyerSigned", "SellerSigned"
        public DateTime OccurredAtUtc { get; set; } = DateTime.UtcNow;
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
    }
}
