using CoAntiCor.Core.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CoAntiCor.Core.Domain
{
    /// <summary>
    /// 2. Proposed Category Structure
    /// To classify all your incident types cleanly, here are the parent categories:
    /// 1. Financial Misconduct
    /// - Embezzlement
    /// - Fraud
    /// - Money Laundering
    /// - Tax Evasion
    /// - Illegal Acquisition of Public Property
    /// - Misuse of Public Resources
    /// 2. Administrative Misconduct
    /// - Conflict of Interest
    /// - Abuse of Power
    /// - Nepotism
    /// - Hiring Favoritism
    /// - Abuse of Personnel
    /// 3. Corruption & Influence
    /// - Bribery
    /// - Extortion
    /// - Public Procurement Fraud
    /// 4. Land & Property Disputes
    /// - Land Dispute
    /// - Land Grabbing
    /// - Confiscation of Property Belonging to Other
    /// 5. Document & Information Crimes
    /// - Falsification
    /// - Illegal Reproduction
    /// - Illegal Publication
    /// 6. Sexual Misconduct
    /// - Sexual Harassment
    /// </summary>
    public class IncidentType : EntityBaseObject
    {
        public string Name { get; set; } = default!; // Tax Evasion, Conflict of Interest, etc.
        public string? Description { get; set; }
        public string NameFrench { get; set; } = default!; // Government Fraud, Local Bribery, etc.
        public string? DescriptionFrench { get; set; }

        public Guid IncidentCategoryId { get; set; }
        public IncidentCategory IncidentCategory { get; set; } = default!;
        public ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();
    }
}
