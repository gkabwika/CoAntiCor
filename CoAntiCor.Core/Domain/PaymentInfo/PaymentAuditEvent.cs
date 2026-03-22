
namespace CoAntiCor.Core.Domain.Organization.PaymentInfo
{
    public class PaymentAuditEvent
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? PaymentId { get; set; }
        public Guid? ServiceRequestId { get; set; }
        public string Method { get; set; } = string.Empty;
        public string EventType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string? Payload { get; set; }
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;
        public string? PerformedBy { get; set; }
        public string? Source { get; set; }
    }

}
