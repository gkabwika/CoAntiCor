namespace CoAntiCor.Core.Domain
{
    public class ServiceRequest
    {
        public Guid Id { get; set; }
        public long ServiceRequestNumber { get; set; }
        public string ServiceName { get; set; } = default!;
        public string ServiceAttribute { get; set; } = default!;
        public string ServiceType { get; set; } = default!;
        public string Status { get; set; } = "Submitted"; //"Submitted";
        public int ServiceStandardDays { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTime? SubmittedAt { get; set; }

    }
}
