using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.DTO.Incident
{
    public class CreateIncidentRequestDto
    {
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
    }
}
