using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.DTO.Incident
{
    public class WorkflowDraftDto
    {
        public Guid DraftId { get; set; }
        public int CurrentStep { get; set; }
        public int Version { get; set; }

        public string? SearchQuery { get; set; }
        public string? AccessCode { get; set; }

        public Guid? IncidentTypeId { get; set; }
        public Guid? IncidentCategoryId { get; set; }
        public string? IncidentTypeOther { get; set; }
        public string? CategoryOther { get; set; }

        public bool IsAnonymous { get; set; } = true;
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

        public string? Title { get; set; }
        public string? Description { get; set; }
    }

}
