using CoAntiCor.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Domain.ServiceRequest
{
    public class IncidentRequest:EntityBaseObject
    {
        public new Guid Id { get; set; }
        public string IncidentNumber { get; set; } = default!;

        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;

        public string IncidentType { get; set; } = default!;   // e.g. "Fraud", "ConflictOfInterest"
        public string Category { get; set; } = default!;       // finer-grained reason

        public string Province { get; set; } = default!;
        public string City { get; set; } = default!;

        public bool IsAnonymous { get; set; }

        public string? CitizenName { get; set; }
        public string? CitizenEmail { get; set; }
        public string? CitizenPhone { get; set; }

        public IncidentStatus Status { get; set; } = IncidentStatus.Draft;

        public DateTime CreatedAt { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }

        public Guid? CreatedByUserId { get; set; }

        public ICollection<IncidentEvidence> EvidenceFiles { get; set; } = new List<IncidentEvidence>();
        public ICollection<ProcessingPhaseHistory> PhaseHistory { get; set; } = new List<ProcessingPhaseHistory>();
    }
}
