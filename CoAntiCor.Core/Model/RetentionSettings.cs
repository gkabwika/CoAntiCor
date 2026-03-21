
namespace CoAntiCor.Core.Model
{
    // Attachments (evidence) -  Technical enforcement
    // - Configuration-driven retentio

    public class RetentionSettings
    {
        public int ComplaintYearsAfterClosure { get; set; } = 15;
        public int AuthLogYears { get; set; } = 5;
        public int AuditLogYears { get; set; } = 25;
    }
}
