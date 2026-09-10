using CoAntiCor.Core.Enums;
using CoAntiCor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.DTO.Incident
{
    public class IncidentRequestDto
    {
        public Guid Id { get; set; }
        public string IncidentNumber { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string IncidentType { get; set; } = default!;
        public string Category { get; set; } = default!;
        public string Province { get; set; } = default!;
        public string City { get; set; } = default!;
        public bool IsAnonymous { get; set; }
        public string? CitizenName { get; set; }
        public string? CitizenEmail { get; set; }
        public string? CitizenPhone { get; set; }
        public IncidentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public string IncidentCategory { get; set; } = default!;
        public string? ReporterName { get; set; } 

        public List<AttachmentDto> Attachments { get; set; } = new();
        public List<HistoryDto> History { get; set; } = new();
        public List<ProcessingPhaseDto> Phases { get; set; } = new();
    }

}
