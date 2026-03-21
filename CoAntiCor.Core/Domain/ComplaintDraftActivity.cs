
namespace CoAntiCor.Core.Domain
{
    public class ComplaintDraftActivity : EntityBaseObject
    {
        public Guid DraftId { get; set; }
        public ComplaintDraft Draft { get; set; } = default!;

        public DateTime TimestampUtc { get; set; }
        public string Action { get; set; } = default!; // e.g. "StepCompleted", "Autosave", "DeviceLinked"
        public int? StepNumber { get; set; }

        public string DeviceName { get; set; } = default!;
        public string DeviceType { get; set; } = default!; // "Mobile", "Desktop", "Tablet"
        public string Browser { get; set; } = default!;
        public string IpAddress { get; set; } = default!;
    }
}
