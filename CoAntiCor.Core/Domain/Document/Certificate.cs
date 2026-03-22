
namespace CoAntiCor.Core.Domain.Organization.Document
{
    public class Certificate
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Guid ServiceRequestId { get; set; }
        public string CertificateNumber { get; set; } = default!;
        public DateTimeOffset IssuedAt { get; set; } = DateTimeOffset.UtcNow;
    }


}
