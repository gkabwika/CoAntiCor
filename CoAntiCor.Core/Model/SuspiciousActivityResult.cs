
namespace CoAntiCor.Core.Model
{
    public class SuspiciousActivityResult
    {
        public Guid DraftId { get; set; }
        public double RiskScore { get; set; } // 0–100
        public List<string> Flags { get; set; } = new();
        public bool RequiresReview => RiskScore >= 70;
    }
}
