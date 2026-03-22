using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Domain
{
    public class IncidentType : EntityBaseObject
    {
        public string Name { get; set; } = default!; // Tax Evasion, Conflict of Interest, etc.
        public string? Description { get; set; }
        public string NameFrench { get; set; } = default!; // Government Fraud, Local Bribery, etc.
        public string? DescriptionFrench { get; set; }

        public ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();
    }
}
