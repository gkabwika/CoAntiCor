using CoAntiCor.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.DTO.Incident
{
    public class ServiceRequestDto
    {
        public Guid Id { get; set; }
        public string IncidentNumber { get; set; } = default!;
        public string Province { get; set; } = default!;
        public string Category { get; set; } = default!;
        public string IncidentType { get; set; } = default!;
        public IncidentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
