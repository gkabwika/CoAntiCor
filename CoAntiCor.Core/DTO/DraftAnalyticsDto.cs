namespace CoAntiCor.Core.DTO
{
    public class DraftAnalyticsDto
    {
        public int TotalDrafts { get; set; }
        public int ActiveDrafts { get; set; }
        public int CompletedDrafts { get; set; }
        public int AbandonedDrafts { get; set; }

        public Dictionary<int, int> StepDropoffCounts { get; set; } = new();
        public Dictionary<string, int> DeviceTypeCounts { get; set; } = new();
        public Dictionary<string, int> BrowserCounts { get; set; } = new();

        public double AvgTimeToCompleteMinutes { get; set; }
        public double AvgTimeBetweenStepsSeconds { get; set; }

        public List<DailyDraftCount> DailyDrafts { get; set; } = new();
    }

    public class DailyDraftCount
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}
