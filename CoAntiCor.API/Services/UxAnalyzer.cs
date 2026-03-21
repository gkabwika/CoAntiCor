using CoAntiCor.Core.DTO;
using CoAntiCor.Core.Interfaces;
using CoAntiCor.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CoAntiCor.API.Services
{
    /// <summary>
    ///  Citizen UX Optimization Report (Based on Analytics)
    ///This report uses:
    ///- Draft analytics
    ///- Heatmap data
    ///- Suspicious activity patterns
    ///- Drop-off points
    ///- Device usage
    ///It produces actionable recommendations for improving the citizen experience.
    /// </summary>
    public class UxAnalyzer : IUxAnalyzer
    {
        private readonly CoAntiCorDbContext _db;

        public UxAnalyzer(CoAntiCorDbContext db)
        {
            _db = db;
        }

        public async Task<UxOptimizationReport> GenerateReportAsync()
        {
            var drafts = await _db.ComplaintDrafts.ToListAsync();
            var activities = await _db.ComplaintDraftActivities.ToListAsync();

            var report = new UxOptimizationReport();

            // 1. Drop-off analysis
            var dropoff = activities
                .Where(a => a.Action == "StepCompleted")
                .GroupBy(a => a.StepNumber)
                .ToDictionary(g => g.Key, g => g.Count());

            if (dropoff.TryGetValue(2, out var step2) &&
                dropoff.TryGetValue(3, out var step3) &&
                step3 < step2 * 0.7)
            {
                report.KeyFindings.Add("High drop-off between Step 2 and Step 3.");
                report.Recommendations.Add("Simplify Step 3 or reduce required fields.");
            }

            // 2. Device usage
            var mobileUsage = activities.Count(a => a.DeviceType == "Mobile");
            var desktopUsage = activities.Count(a => a.DeviceType == "Desktop");

            if (mobileUsage > desktopUsage * 1.5)
            {
                report.KeyFindings.Add("Majority of users report from mobile devices.");
                report.Recommendations.Add("Optimize wizard layout for mobile-first experience.");
            }

            // 3. Time-of-day patterns
            var nightDrafts = drafts.Count(d => d.LastUpdatedUtc.Hour >= 20 || d.LastUpdatedUtc.Hour < 6);
            if (nightDrafts > drafts.Count * 0.4)
            {
                report.KeyFindings.Add("High reporting activity during night hours.");
                report.Recommendations.Add("Ensure server capacity and SMS/email delivery reliability at night.");
            }

            // 4. Abandoned drafts
            var abandoned = drafts.Count(d => !d.IsCompleted && d.LastUpdatedUtc < DateTime.UtcNow.AddDays(-7));
            if (abandoned > drafts.Count * 0.3)
            {
                report.KeyFindings.Add("Significant number of abandoned drafts.");
                report.Recommendations.Add("Add reminders or simplify early steps.");
            }

            return report;
        }
    }
}
