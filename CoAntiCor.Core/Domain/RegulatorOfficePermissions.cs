
namespace CoAntiCor.Core.Domain
{
    public class RegulatorOfficePermission :EntityBaseObject
    {
        public new Guid Id { get; set; } = Guid.NewGuid();

        // The regulator / executive user
        public Guid UserId { get; set; }
        public ApplicationUser? User { get; set; }

        // The office this regulator is allowed to impersonate / see
        public Guid OfficeId { get; set; }
        public BrokerOffice? Office { get; set; }

        // Optional: province scoping for this permission (if you want)
        public string? ProvinceCode { get; set; }

        // Optional: audit / metadata
        public DateTime GrantedAtUtc { get; set; } = DateTime.UtcNow;
        public Guid? GrantedByUserId { get; set; }
    }
}
