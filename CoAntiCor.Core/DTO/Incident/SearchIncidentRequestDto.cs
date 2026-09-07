using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.DTO.Incident
{
    public class SearchIncidentRequestDto
    {
        public string? Query { get; set; }
        public string? IncidentType { get; set; }
        public string? Province { get; set; }
        public string? Category { get; set; }
    }
}
