using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Domain
{
    /// <summary>
    /// We already have IncidentType (the specific misconduct).
    /// Now we want IncidentCategory — the parent grouping.
    /// This is exactly how national anti‑corruption systems structure their taxonomies:
    /// Incident Category → Incident Type → Complaint
    /// </summary>
    public class IncidentCategory : EntityBaseObject
    {
        public string Code { get; set; } = default!; 
        public string Name { get; set; } = default!; // Government Fraud, Local Bribery, etc.
        public string? Description { get; set; }
        public string NameFrench { get; set; } = default!; // Government Fraud, Local Bribery, etc.
        public string? DescriptionFrench { get; set; }
      
        public ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();
        public ICollection<IncidentType> IncidentTypes { get; set; } = new List<IncidentType>();

    }
}
