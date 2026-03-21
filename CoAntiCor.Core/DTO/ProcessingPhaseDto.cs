using CoAntiCor.Core.Model;

namespace CoAntiCor.Core.DTO
{
    public class ProcessingPhaseDto
    {
        public ProcessingPhaseType PhaseType { get; set; }
        public ProcessingPhaseStatus Status { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string AssignedTo { get; set; }
        public string Comments { get; set; }
    }
}