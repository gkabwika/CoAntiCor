using CoAntiCor.Core.Model;

namespace CoAntiCor.Core.Domain
{
    public class ProcessingPhase : EntityBaseObject
    {

        public Guid ComplaintId { get; set; }
        public Complaint Complaint { get; set; } = default!;

        public ProcessingPhaseType PhaseType { get; set; }
        public ProcessingPhaseStatus Status { get; set; }

        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        public Guid? AssignedToUserId { get; set; }
        public User? AssignedToUser { get; set; }

        public string? Comments { get; set; }
    }
}
