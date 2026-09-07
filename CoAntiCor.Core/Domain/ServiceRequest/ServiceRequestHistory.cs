using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Domain.ServiceRequest
{
    public class ServiceRequestHistory : EntityBaseObject
    {
        public Guid Id { get; set; }
        public Guid IncidentId { get; set; }
        public string Phase { get; set; } = default!;
        public string Status { get; set; } = default!;
        public string? Notes { get; set; }
        public Guid? ChangedByUserId { get; set; }
        public DateTime ChangedAt { get; set; }
    }

}
