using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.DTO
{
    public class ReportIncidentWizardState
    {
        // Step 1 - AI search
        public string? SearchQuery { get; set; }
        public List<SimilarIncidentDto> SimilarIncidents { get; set; } = new();
        public DateTime? LastSavedUtc { get; set; }
        public bool IsSaving { get; set; }

        // Step 2 - classification
        public int? IncidentTypeId { get; set; }
        public int? IncidentCategoryId { get; set; }

        // Step 3 - reporter & evidence
        public bool IsAnonymous { get; set; }
        public string? ReporterName { get; set; }
        public string? DraftAccessCode { get; set; }
        
        public string? ReporterEmail { get; set; }
        public string? ReporterPhone { get; set; }

        public int? GovernmentOfficeId { get; set; }

        public List<UploadedFileDto> EvidenceFiles { get; set; } = new();

        // Core complaint info
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string? Province { get; set; }
        public string? City { get; set; }
    }
}
