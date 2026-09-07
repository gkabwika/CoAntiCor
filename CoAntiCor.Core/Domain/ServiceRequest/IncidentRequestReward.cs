using CoAntiCor.Core.Domain.ServiceRequest;
using CoAntiCor.Core.Model;

namespace CoAntiCor.Core.Domain.ServiceRequest
{
    public class IncidentRequestReward : EntityBaseObject
    {
        public Guid IncidentRequestId { get; set; }
        public IncidentRequest IncidentRequest { get; set; } = default!;

        public RewardEligibilityStatus EligibilityStatus { get; set; }

        public decimal? Amount { get; set; }
        public DateTime? DecisionDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public string? PaymentReference { get; set; }
    }
}
