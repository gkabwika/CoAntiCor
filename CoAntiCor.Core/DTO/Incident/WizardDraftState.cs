using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Domain.Person;
using CoAntiCor.Core.Domain.ServiceRequest;
using CoAntiCor.Core.DTO.Incident.CoAntiCor.Core.DTO.Incident;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.DTO.Incident
{
    public class WizardDraftState
    {
        public Guid DraftId { get; set; }
        public int CurrentStep { get; set; }
        public int Version { get; set; }
        public List<SimilarIncidentDto> SimilarIncidents { get; set; } = new();
        public IncidentRequestDto IncidentRequest { get; set; } = new();
        public IncidentDetailDto IncidentDetail { get; set; } = new();
        public IncidentSecurityDetailDto SecurityDetail { get; set; } = new();
        // Step 1
        public string? SearchQuery { get; set; }
        public string? AccessCode { get; set; }

        // Step 2
        public Guid? IncidentTypeId { get; set; }
        public Guid? IncidentCategoryId { get; set; }
        public string? IncidentTypeOther { get; set; }
        public string? CategoryOther { get; set; }

        // Step 3
   
        public ICollection<NaturalPerson> People { get; set; } = new List<NaturalPerson>();

        public bool IsAnonymous { get; set; }
        public string? CitizenName { get; set; }
        public string? CitizenEmail { get; set; }
        public string? CitizenPhone { get; set; }
        public string? Sex { get; set; }
        public int? AgeGroup { get; set; }
        public string? AgeGroups { get; set; }
        public string? Service { get; set; }
        public string? JobRole { get; set; }
        public string? ReporterFullName { get; set; }
        public string? ReporterName { get; set; }
        public string? ReporterEmail { get; set; }
        public string? ReporterPhone { get; set; }
    
        // Step 4
        public Guid? ProvinceId { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public string? Commune { get; set; }
        public string? Quartier { get; set; }
        public string? Address { get; set; }
        public Guid? GovernmentOfficeId { get; set; }

        // Step 5
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<AttachmentDraftItem> Attachments { get; set; } = new();

        // Step 6
        public string? IdentityChoice { get; set; } // "anonymous", "fake", "real"

        // Step 7 – review only (no extra fields)
    }

}
