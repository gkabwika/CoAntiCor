using CoAntiCor.Core.Model;

namespace CoAntiCor.Core.DTO
{
    public class ComplaintDetailDto
    {
        public Guid Id { get; set; }
        public string ComplaintNumber { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string IncidentType { get; set; } = default!;
        public string IncidentCategory { get; set; } = default!;
        public ComplaintStatus Status { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ReporterName { get; set; }
        public bool IsAnonymous { get; set; }
        
        public List<AttachmentDto> Attachments { get; set; } = new();
        public List<HistoryDto> History { get; set; } = new();
        public List<ProcessingPhaseDto> Phases { get; set; } = new();
    }


}
