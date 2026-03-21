using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Domain
{
    public class IncidentCategory : EntityBaseObject
    {
        public string Name { get; set; } = default!; // Government Fraud, Local Bribery, etc.
        public string? Description { get; set; }

        public ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();
    }
}
