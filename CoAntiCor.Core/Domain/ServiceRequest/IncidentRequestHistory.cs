using CoAntiCor.Core.Domain.ServiceRequest;
using CoAntiCor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Domain.ServiceRequest
{
    public class IncidentRequestHistory : EntityBaseObject
    {

        public Guid IncidentRequestId { get; set; }
        public IncidentRequest IncidentRequest { get; set; } = default!;

        public ComplaintStatus OldStatus { get; set; }
        public ComplaintStatus NewStatus { get; set; }

        public Guid ChangedByUserId { get; set; }
        public User ChangedByUser { get; set; } = default!;

        public DateTime ChangedAt { get; set; }

        public string? Comment { get; set; }
    }
}

