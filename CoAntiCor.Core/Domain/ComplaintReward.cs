using CoAntiCor.Core.Model;

namespace CoAntiCor.Core.Domain
{
    public class ComplaintReward : EntityBaseObject
    {
        public Guid ComplaintId { get; set; }
        public Complaint Complaint { get; set; } = default!;

        public RewardEligibilityStatus EligibilityStatus { get; set; }

        public decimal? Amount { get; set; }
        public DateTime? DecisionDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public string? PaymentReference { get; set; }
    }
}
