namespace CoAntiCor.Core.DTO
{
    public class DeviceSecurityReportDto
    {
        public Guid DraftId { get; set; }
        public List<DeviceAccessEntry> AccessEntries { get; set; } = new();
        public List<DeviceLinkAttempt> LinkAttempts { get; set; } = new();
    }

    public class DeviceAccessEntry
    {
        public DateTime TimestampUtc { get; set; }
        public string DeviceType { get; set; } = default!;
        public string Browser { get; set; } = default!;
        public string IpAddress { get; set; } = default!;
    }

    public class DeviceLinkAttempt
    {
        public DateTime TimestampUtc { get; set; }
        public bool Success { get; set; }
        public string Method { get; set; } = default!; // "QR" or "PIN"
        public string IpAddress { get; set; } = default!;
    }
}
