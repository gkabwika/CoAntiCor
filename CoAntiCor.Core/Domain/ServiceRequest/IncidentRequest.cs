using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Domain.Organization.OrganizationDetails;
using CoAntiCor.Core.Domain.Person;
using CoAntiCor.Core.Enums;
using CoAntiCor.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Domain.ServiceRequest
{
    public class IncidentRequest:EntityBaseObject
    {
        public new Guid Id { get; set; }
        public string IncidentNumber { get; set; } = default!;

        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;

        public Guid IncidentTypeId { get; set; }
        [Display(Name = "Incident Type")]
        public IncidentType? IncidentType { get; set; } = default!;
        public Guid IncidentCategoryId { get; set; }
        [Display(Name = "Incident Category")]
        public IncidentCategory? IncidentCategory { get; set; } = default!;
        public string IncidentTypeOther { get; set; } = default!;   // e.g. "Fraud", "ConflictOfInterest"
        public string Category { get; set; } = default!;       // finer-grained reason

        public string Province { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Commune { get; set; } = default!;
        public string Quartier { get; set; } = default!;
        public string Address { get; set; } = default!;

        public bool IsAnonymous { get; set; }

        public string? CitizenName { get; set; }
        public string? CitizenEmail { get; set; }
        public string? CitizenPhone { get; set; }
        public string? Service { get; set; }
        public string? JobRole { get; set; }
        public string? Sex { get; set; }
        public string? AgeGroups { get; set; }
        public int? AgeGroup { get; set; }  //1=1-18, 2=19-35, 3=36-60, 4=60+  
        public string? ReporterFullName { get; set; }
        //public Guid NaturalPersonId { get; set; }
        //[ForeignKey(nameof(NaturalPersonId))]
        [Display(Name = "Person Details")]
        public ICollection<NaturalPerson> Persons { get; set; } = new List<NaturalPerson>();

        [Display(Name = "Organization Details")]
        public ICollection<PhysicPerson> Organizations { get; set; } = new List<PhysicPerson>();

        public Guid GovernmentOfficeId { get; set; }
        public GovernmentOffice? GovernmentOffice { get; set; }
        public IncidentStatus Status { get; set; } = IncidentStatus.Draft;
        public Guid? ReporterUserId { get; set; }
        public User? ReporterUser { get; set; }
        public Guid? AssignedToUserId { get; set; }
        // Navigation property
        [ForeignKey(nameof(AssignedToUserId))] 
        public User? AssignedToUser { get; set; }
        public string OfficialNotes { get; set; } = default!;
        [Display(Name = "Official Discussions")]
        public ICollection<OfficialDiscussion> OfficialDiscussions { get; set; } = new List<OfficialDiscussion>();
        public DateTime CreatedAt { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }

        public Guid? CreatedByUserId { get; set; }

        public ICollection<IncidentEvidence> EvidenceFiles { get; set; } = new List<IncidentEvidence>();
        public ICollection<ComplaintAttachment> Attachments { get; set; } = new List<ComplaintAttachment>();
        public ICollection<ProcessingPhaseHistory> PhaseHistory { get; set; } = new List<ProcessingPhaseHistory>();
        public ICollection<IncidentRequestHistory> History { get; set; } = new List<IncidentRequestHistory>();
        public ICollection<IncidentRequestReward> IncidentRequestRewards { get; set; } = new List<IncidentRequestReward>();
      
    }
}
