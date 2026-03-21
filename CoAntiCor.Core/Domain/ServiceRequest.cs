using CoAntiCor.Core.Domain;

namespace CoAntiCor.Data.Entities
{
    public class ServiceRequest : EntityBaseObject
    {
        public long ServiceRequestNumber { get; set; }
        public string ServiceName { get; set; } = default!;
        public string ServiceAttribute { get; set; } = default!;
        public DateTime SubmittedOn { get; set; }
        public int ServiceStandardDays { get; set; }
        public string Status { get; set; } = "Submitted";
        public string? TenantId { get; internal set; }
    }

}
