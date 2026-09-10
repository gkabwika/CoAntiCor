using CoAntiCor.API.Services.Interface;
using CoAntiCor.Core.Domain.ServiceRequest;

namespace CoAntiCor.API.Services
{

    public class IncidentSecurityRiskService : IIncidentSecurityRiskService
    {
        public IncidentSecurityDetail ComputeRisk(IncidentSecurityDetail detail)
        {
            int score = 0;

            // Network risk
            if (detail.VpnDetected) score += 15;
            if (detail.ProxyDetected) score += 10;
            if (detail.TorDetected) score += 25;
            if (detail.HostingProviderDetected) score += 20;

            // Behavior risk
            if (detail.SuspiciousInteractionScore > 70) score += 20;
            if (detail.SubmissionAttemptCount > 3) score += 10;
            if (detail.RepeatedSubmissionDetected) score += 20;
            if (detail.DuplicateContentDetected) score += 20;

            // System integrity
            if (!detail.JavascriptEnabled) score += 10;
            if (!detail.CookiesEnabled) score += 5;

            // Blacklist / whitelist
            if (detail.BlacklistHit) score += 40;
            if (detail.WhitelistHit) score -= 20;

            // Clamp
            if (score < 0) score = 0;
            if (score > 100) score = 100;

            detail.RiskScore = score;
            detail.RiskLevel = score switch
            {
                <= 20 => "Low",
                <= 40 => "Medium",
                <= 70 => "High",
                _ => "Critical"
            };

            detail.HighRiskPatternDetected = score >= 70;

            return detail;
        }
    }

}
