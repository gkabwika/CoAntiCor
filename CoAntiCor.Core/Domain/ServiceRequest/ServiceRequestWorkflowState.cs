using CoAntiCor.Core.Domain.Organization.OrganizationDetails;
using CoAntiCor.Core.Domain.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Domain.ServiceRequest
{
    public class ServiceRequestWorkflowState : EntityBaseObject
    {
        public new Guid Id { get; set; } = Guid.NewGuid();
        public Guid DraftId { get; set; } = Guid.NewGuid();
        public int CurrentStep { get; set; } = 1;
        //“Draft Autosave” Indicator UI
        public string Code { get; set; } = default!;
        public string LabelFr { get; set; } = default!;
        public string LabelEn { get; set; } = default!;
        public int Order { get; set; }
        public DateTime? LastSavedUtc { get; set; }
        public bool IsSaving { get; set; }
        public Dictionary<int, DateTime> StepCompletedUtc { get; set; } = new(); // key = step number //Map as a JSON Column (EF Core 8+ Recommended)

        // Step 1
        public string? SearchQuery { get; set; }
        public string? AccessCode { get; set; }

        // Step 2
        public Guid? IncidentTypeId { get; set; }
        public Guid? IncidentCategoryId { get; set; }
        public string? IncidentTypeOther { get; set; }
        public string? CategoryOther { get; set; }
        // Step 3
        public bool IsAnonymous { get; set; } = true;
        public int Version { get; set; } = 0; // Incremented on each save to detect conflicts
        public string? IdentityChoice { get; set; }
        public string? Sex { get; set; }
        public int? AgeGroup { get; set; }
        public string? AgeGroups { get; set; }
        public string? Service { get; set; }
        public string? JobRole { get; set; }
        public string? ReporterFullName { get; set; }
        public string? ReporterName { get; set; }
        public string? ReporterEmail { get; set; }
        public string? ReporterPhone { get; set; }
        public Guid? ProvinceId { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public string? Commune { get; set; }
        public string? Quartier { get; set; }
        public string? Address { get; set; }
        public Guid? GovernmentOfficeId { get; set; }

        public Guid NaturalPersonId { get; set; } // Company / societe
        [ForeignKey(nameof(NaturalPersonId))]
        [Display(Name = " Reporter Person Details")]
        public ICollection<NaturalPerson> ReporterPersons { get; set; } = new List<NaturalPerson>();

        [Display(Name = " Victim Person Details")]
        public ICollection<NaturalPerson> VictimPersons { get; set; } = new List<NaturalPerson>();

        public Guid PhysicPersonId { get; set; } // Company / societe
        [ForeignKey(nameof(PhysicPersonId))]
        [Display(Name = " Reporter Organization Details")]
        public ICollection<PhysicPerson> ReporterOrganizations { get; set; } = new List<PhysicPerson>();

        [Display(Name = " Victim Organization Details")]
        public ICollection<PhysicPerson> VictimOrganizations { get; set; } = new List<PhysicPerson>();

        // Step 4
        public string? Title { get; set; }
        public string? Description { get; set; }

        // Attachments: store temp IDs/paths
        public List<AttachmentDraftItem> Attachments { get; set; } = new();
        //Draft Conflict Resolution Flow (Two Devices Editing at Once)
        //This is essential for multi-device editing. We’ll implement a Last-Write-Wins with Merge Prompt strategy.


    }

}
