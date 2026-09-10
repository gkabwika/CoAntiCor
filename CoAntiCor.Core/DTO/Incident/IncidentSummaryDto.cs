using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace CoAntiCor.Core.DTO.Incident
{
    public class IncidentSummaryDto
    {
        public Guid Id { get; set; }

        public string IncidentNumber { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Category { get; set; } = default!;
        public string IncidentType { get; set; } = default!;

        public string Province { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Commune { get; set; } = default!;
        public string Quartier { get; set; } = default!;

        public DateTime CreatedAt { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }

        public string Status { get; set; } = default!;

        // Dashboard counters
        public int OpenCount { get; set; }
        public int ClosedCount { get; set; }
        public int PendingCount { get; set; }
    }
}
