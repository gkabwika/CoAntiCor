
namespace CoAntiCor.Core.Domain
{
    public class IntegrityLog : EntityBaseObject
    {
        public string ObjectType { get; set; } = default!; // "Contract"
        public Guid ObjectId { get; set; }

        public string HashAlgorithm { get; set; } = "SHA256";
        public string HashHex { get; set; } = default!;

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public string CreatedByUserId { get; set; } = default!;
    }
}
