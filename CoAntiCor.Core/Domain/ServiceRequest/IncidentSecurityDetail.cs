using CoAntiCor.Core.Domain.Address;
using CoAntiCor.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Domain.ServiceRequest
{
    /// <summary>
    /// Recommended Security & Privacy Metadata
    /// These are the standard fields collected by cybersecurity, fraud‑detection, and national‑security systems.
    /// How to Collect These Fields (No User Consent Required): 
    /// - Automatically collected by browser:UserAgent, Browser version,OS, Screen resolution, Language, Platform, Timezone, Cookies enabled, LocalStorage enabled,Referrer URL
    /// - Automatically collected by server: IP address, ISP, Country, City, VPN / Proxy / Tor detection, Hosting provider detection, Session ID, First/last access timestamps
    /// - Automatically collected by your JS client :Typing speed, Mouse movement pattern,Touch pressure,Interaction intervals, Device model, Device manufacturer
    /// - Automatically collected by your fraud engine: Risk score, Duplicate detection, Repeated submission detection, Bot suspicion, High‑risk pattern detection
    /// </summary>
    public class IncidentSecurityDetail : EntityBaseObject
    {
        public new Guid Id { get; set; }
        public Guid IncidentRequestId { get; set; }

        // Device Identity
        public string? DeviceId { get; set; }
        public string? DeviceModel { get; set; }
        public string? DeviceManufacturer { get; set; }
        public string? DeviceOS { get; set; }
        public string? DeviceOSVersion { get; set; }
        public string? BrowserName { get; set; }
        public string? BrowserVersion { get; set; }
        public string? UserAgentString { get; set; }
        public string? ScreenResolution { get; set; }
        public bool IsMobileDevice { get; set; }
        public bool IsBotSuspected { get; set; }

        // Network Identity
        public string? IpAddress { get; set; }
        public string? IpAddressOriginCountry { get; set; }
        public string? IpAddressOriginCity { get; set; }
        public string? IpAddressOriginISP { get; set; }
        public bool VpnDetected { get; set; }
        public bool ProxyDetected { get; set; }
        public bool TorDetected { get; set; }
        public bool HostingProviderDetected { get; set; }
        public string? NetworkType { get; set; }

        // Geolocation
        public double? GeoLatitude { get; set; }
        public double? GeoLongitude { get; set; }
        public double? GeoAccuracyMeters { get; set; }
        public string? GeoCountry { get; set; }
        public string? GeoCity { get; set; }
        public string? GeoRegion { get; set; }

        // Behavioral Biometrics
        public double? TypingSpeedWPM { get; set; }
        public string? MouseMovementPatternHash { get; set; }
        public string? TouchPressurePatternHash { get; set; }
        public double? InteractionIntervalMs { get; set; }
        public int SuspiciousInteractionScore { get; set; }

        // Submission Metadata
        public DateTime FirstAccessedAtUtc { get; set; }
        public DateTime LastAccessedAtUtc { get; set; }
        public int SubmissionAttemptCount { get; set; }
        public DateTime? SubmissionCompletedAtUtc { get; set; }
        public int SessionDurationSeconds { get; set; }
        public string? SessionId { get; set; }
        public bool SessionReused { get; set; }

        // Fraud / Abuse Indicators
        public bool RepeatedSubmissionDetected { get; set; }
        public bool DuplicateContentDetected { get; set; }
        public bool HighRiskPatternDetected { get; set; }
        public bool BlacklistHit { get; set; }
        public bool WhitelistHit { get; set; }
        public int RiskScore { get; set; }
        public string? RiskLevel { get; set; }

        // System Integrity
        public bool JavascriptEnabled { get; set; }
        public bool CookiesEnabled { get; set; }
        public bool LocalStorageEnabled { get; set; }
        public int TimezoneOffset { get; set; }
        public string? Language { get; set; }
        public string? Platform { get; set; }
        public string? ReferrerUrl { get; set; }
        public string? EntryUrl { get; set; }

        // Navigation
        public IncidentRequest IncidentRequest { get; set; } = default!;
    }

}
