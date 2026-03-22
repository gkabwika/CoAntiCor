using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Enums;

namespace CoAntiCor.Core.Domain.Processing
{
    public class ProcessingPhaseNew : EntityBaseObject
    {
        public Guid WorkItemId { get; set; }
        public WorkItem WorkItem { get; set; } = default!;
        public string Name { get; set; } = default!; // e.g. "RCCM", "Tax Certificate"
        public ProcessingPhaseStatus Status { get; set; }
        public string? Comments { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
