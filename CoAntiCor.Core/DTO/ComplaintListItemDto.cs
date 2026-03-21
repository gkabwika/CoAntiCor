using CoAntiCor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.DTO
{
    public class ComplaintListItemDto
    {
        public Guid Id { get; set; }
        public string ComplaintNumber { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string IncidentType { get; set; } = default!;
        public string IncidentCategory { get; set; } = default!;
        public ComplaintStatus Status { get; set; }
        public string Province { get; set; } = default!;
        public string City { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public string? AssignedTo { get; set; }
    }
}
