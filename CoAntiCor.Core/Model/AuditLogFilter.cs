
namespace CoAntiCor.Core.Model
{
    public class AuditLogFilter
    {
        public AuditActionType? ActionType { get; set; }
        public string? EntityType { get; set; }
        public string? EntityId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }

}
