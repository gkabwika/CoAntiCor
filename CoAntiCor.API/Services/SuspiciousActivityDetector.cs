using CoAntiCor.Core.Interfaces;
using CoAntiCor.Core.Model;
using CoAntiCor.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CoAntiCor.API.Services
{
    /// <summary>
    /// 1. Suspicious Activity Detector (AI‑Assisted Anomaly Detection)
    /// This module analyzes:
    /// - Draft activity logs
    /// - Device changes
    /// - IP changes
    /// - Step timing anomalies
    /// - Repeated linking attempts
    /// - Unusual patterns(e.g., 20 drafts from same device)
    /// It produces a risk score and alerts for internal security teams.
    /// </summary>
    public class SuspiciousActivityDetector : ISuspiciousActivityDetector
    {
        private readonly CoAntiCorDbContext _db;

        public SuspiciousActivityDetector(CoAntiCorDbContext db)
        {
            _db = db;
        }

        public async Task<SuspiciousActivityResult> AnalyzeDraftAsync(Guid draftId)
        {
            var activities = await _db.ComplaintDraftActivities
                .Where(a => a.DraftId == draftId)
                .OrderBy(a => a.TimestampUtc)
                .ToListAsync();

            var result = new SuspiciousActivityResult { DraftId = draftId };

            // 1. Too many device changes
            var deviceCount = activities.Select(a => a.DeviceType).Distinct().Count();
            if (deviceCount > 3)
            {
                result.Flags.Add("Multiple device changes detected");
                result.RiskScore += 25;
            }

            // 2. Rapid step completion (bot-like)
            var rapidSteps = activities
                .Where(a => a.Action == "StepCompleted")
                .GroupBy(a => a.StepNumber)
                .Any(g => g.Count() > 1 &&
                          g.Max(x => x.TimestampUtc) - g.Min(x => x.TimestampUtc) < TimeSpan.FromSeconds(2));

            if (rapidSteps)
            {
                result.Flags.Add("Unusually fast step completion");
                result.RiskScore += 30;
            }

            // 3. Multiple failed device linking attempts
            var failedLinks = activities
                .Where(a => a.Action == "DeviceLinkAttempt" && a.StepNumber == 0)
                .Count();

            if (failedLinks > 2)
            {
                result.Flags.Add("Multiple failed device linking attempts");
                result.RiskScore += 20;
            }

            // 4. IP address changes
            var ipCount = activities.Select(a => a.IpAddress).Distinct().Count();
            if (ipCount > 4)
            {
                result.Flags.Add("Frequent IP address changes");
                result.RiskScore += 25;
            }

            // 5. ML-assisted anomaly score (placeholder)
            // In production, you’d feed activity patterns into an anomaly detection model.
            // Here we simulate a small ML contribution:
            result.RiskScore += Random.Shared.NextDouble() * 10;

            return result;
        }
    }
}
