
namespace CoAntiCor.Core.Domain.Reporting
{
    public class MonthlyAggregate
    {
        public int Id { get; set; }
        public Guid TenantId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string Currency { get; set; } = "USD";
        public decimal TotalRevenue { get; set; }
        public int SuccessfulPayments { get; set; }
        public int FailedPayments { get; set; }
    }
}
