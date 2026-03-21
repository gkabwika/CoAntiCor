using System.ComponentModel;

namespace CoAntiCor.Core.Domain
{
    public class ComplaintDraftState : EntityBaseObject
    {
        public Guid DraftId { get; set; } = Guid.NewGuid();
        public int CurrentStep { get; set; } = 1;
        //“Draft Autosave” Indicator UI
        public DateTime? LastSavedUtc { get; set; }
        public bool IsSaving { get; set; }
        public Dictionary<int, DateTime> StepCompletedUtc { get; set; } = new(); // key = step number


        // Step 1
        public string? SearchQuery { get; set; }
        public string? AccessCode { get; set; }

        // Step 2
        public int? IncidentTypeId { get; set; }
        public int? IncidentCategoryId { get; set; }

        // Step 3
        public bool IsAnonymous { get; set; } = true;
        public string? ReporterName { get; set; }
        public string? ReporterEmail { get; set; }
        public string? ReporterPhone { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public Guid? GovernmentOfficeId { get; set; }

        // Step 4
        public string? Title { get; set; }
        public string? Description { get; set; }

        // Attachments: store temp IDs/paths
        public List<AttachmentDraftItem> Attachments { get; set; } = new();
        //Draft Conflict Resolution Flow (Two Devices Editing at Once)
        //This is essential for multi-device editing. We’ll implement a Last-Write-Wins with Merge Prompt strategy.

        public int Version { get; set; } =0; // Incremented on each save to detect conflicts
    }
}
