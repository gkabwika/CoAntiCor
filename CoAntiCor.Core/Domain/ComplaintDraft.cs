
namespace CoAntiCor.Core.Domain
{
    public class ComplaintDraft : EntityBaseObject
    {
      
        public Guid? ReporterUserId { get; set; }
        public int CurrentStep { get; set; }
        public string StateJson { get; set; } = default!;
        public DateTime LastUpdatedUtc { get; set; }
        public bool IsCompleted { get; set; }
        public string? AccessCode { get; set; } //Generate a 6–8 digit code:
        public string? ResumeUrl { get; set; }
       
        // For anonymous users, we can generate a device link token to allow them to resume their draft on the same device without needing an account
        public string? DeviceLinkToken { get; set; }
        public DateTime? DeviceLinkTokenExpiresUtc { get; set; }
        public string? DeviceLinkPin;
        //Draft Conflict Resolution Flow (Two Devices Editing at Once)
        //This is essential for multi-device editing. We’ll implement a Last-Write-Wins with Merge Prompt strategy.
        public int Version { get; set; }
    }
}
