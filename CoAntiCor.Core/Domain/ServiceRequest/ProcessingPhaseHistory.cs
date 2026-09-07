using CoAntiCor.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Domain.ServiceRequest
{
    public class ProcessingPhaseHistory : EntityBaseObject
    {
        public new Guid Id { get; set; }
        public Guid IncidentRequestId { get; set; }

        public string Phase { get; set; } = default!;        // "Screening", "Investigation", "TribunalSubmission"
        public IncidentStatus Status { get; set; }

        public Guid? ChangedByUserId { get; set; }
        public DateTime ChangedAt { get; set; }

        public string? Notes { get; set; }
    }
}
