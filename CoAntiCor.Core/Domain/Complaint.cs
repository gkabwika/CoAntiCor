using CoAntiCor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Domain
{
    public class Complaint : EntityBaseObject
    {  
        public string ComplaintNumber { get; set; } = default!; // CAC-DRC-2026-000123

        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;

        public int IncidentTypeId { get; set; }
        public IncidentType IncidentType { get; set; } = default!;

        public int IncidentCategoryId { get; set; }
        public IncidentCategory IncidentCategory { get; set; } = default!;

        public string? Province { get; set; }
        public string? City { get; set; }
        public string? Service { get; set; }
        public string? JobRole { get; set; }
        public string? Sex { get; set; }
        public string? AgeGroup { get; set; }
        public string? ReporterName { get; set; }        
        public bool IsAnonymous { get; set; }

        public Guid? ReporterUserId { get; set; }
        public User? ReporterUser { get; set; }

        public string? ReporterContactEmail { get; set; }
        public string? ReporterContactPhone { get; set; }

        public ComplaintStatus Status { get; set; }

        public int? GovernmentOfficeId { get; set; }
        public GovernmentOffice? GovernmentOffice { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Guid? AssignedToUserId { get; set; }
        public User? AssignedToUser { get; set; }
     
        public ICollection<ComplaintAttachment> Attachments { get; set; } = new List<ComplaintAttachment>();
        public ICollection<ProcessingPhase> ProcessingPhases { get; set; } = new List<ProcessingPhase>();
        public ICollection<ComplaintHistory> History { get; set; } = new List<ComplaintHistory>();
        public ComplaintReward? Reward { get; set; }
    }
}
