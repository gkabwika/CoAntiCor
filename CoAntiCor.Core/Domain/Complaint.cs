using CoAntiCor.Core.Domain.Organization.OrganizationDetails;
using CoAntiCor.Core.Domain.Person;
using CoAntiCor.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name = "Other Incident Types")]
        public ICollection<IncidentType> OtherIncincidentTypes { get; set; } = new List<IncidentType>();
        public int IncidentCategoryId { get; set; }
        public IncidentCategory IncidentCategory { get; set; } = default!;
        [Display(Name = "Other Incident Category")]
        public ICollection<IncidentCategory> OtherIncidentCategorys { get; set; } = new List<IncidentCategory>();
        public string? Province { get; set; }
        public string? City { get; set; }
        public string? Service { get; set; }
        public string? JobRole { get; set; }
        public string? Sex { get; set; }
        public string? AgeGroups { get; set; }
        public string? ReporterName { get; set; }
        public bool IsAnonymous { get; set; }
        public int? AgeGroup { get; set; }  //1=1-18, 2=19-35, 3=36-60, 4=60+

        public Guid? ReporterUserId { get; set; }
        public User? ReporterUser { get; set; }

        public string? ReporterContactEmail { get; set; }
        public string? ReporterContactPhone { get; set; }

        public Guid NaturalPersonId { get; set; }
        [ForeignKey(nameof(NaturalPersonId))]
        [Display(Name = " Reporter Person Details")]
        public ICollection<NaturalPerson> ReporterPersons { get; set; } = new List<NaturalPerson>();

        [Display(Name = " Victim Person Details")]
        public ICollection<NaturalPerson> VictimPersons { get; set; } = new List<NaturalPerson>();

        public Guid PhysicPersonId { get; set; } // Company / societe
        [ForeignKey(nameof(PhysicPersonId))]
        [Display(Name = " Reporter Person Details")]
        public ICollection<PhysicPerson> ReporterOrganizations { get; set; } = new List<PhysicPerson>();

        [Display(Name = " Victim Organization Details")]
        public ICollection<PhysicPerson> VictimOrganizations { get; set; } = new List<PhysicPerson>();
        public ComplaintStatus Status { get; set; }

        public int? GovernmentOfficeId { get; set; }
        public GovernmentOffice? GovernmentOffice { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Guid? AssignedToUserId { get; set; }
        public User? AssignedToUser { get; set; }
        public string OfficialNotes { get; set; } = default!;
        [Display(Name = "Official Discussions")]
        public ICollection<OfficialDiscussion> OfficialDiscussions { get; set; } = new List<OfficialDiscussion>();


        public ICollection<ComplaintAttachment> Attachments { get; set; } = new List<ComplaintAttachment>();
        public ICollection<ProcessingPhase> ProcessingPhases { get; set; } = new List<ProcessingPhase>();
        public ICollection<ComplaintHistory> History { get; set; } = new List<ComplaintHistory>();
        public ICollection<ComplaintAttachment> OfficialEvidences { get; set; } = new List<ComplaintAttachment>();

        public ComplaintReward? Reward { get; set; }
    }
}
