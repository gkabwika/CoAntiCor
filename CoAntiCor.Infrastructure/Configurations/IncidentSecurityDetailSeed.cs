using CoAntiCor.Core.Domain.ServiceRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Infrastructure.Configurations
{
    public static class IncidentSecurityDetailSeed
    {
        public static List<IncidentSecurityDetail> GetSeed()
        {
            return new List<IncidentSecurityDetail>
        {
            // SAMPLE 1 — Normal citizen, no risk
            new IncidentSecurityDetail
            {
                Id = Guid.NewGuid(),
                IncidentRequestId = Guid.Parse("51000000-0000-0000-0000-000000000004"),

                DeviceId = "dev-9f2a1c",
                DeviceModel = "iPhone 13",
                DeviceManufacturer = "Apple",
                DeviceOS = "iOS",
                DeviceOSVersion = "17.2",
                BrowserName = "Safari",
                BrowserVersion = "17.0",
                UserAgentString = "Mozilla/5.0 (iPhone; CPU iPhone OS 17_2 like Mac OS X)...",
                ScreenResolution = "1170x2532",
                IsMobileDevice = true,
                IsBotSuspected = false,

                IpAddress = "24.48.102.91",
                IpAddressOriginCountry = "Canada",
                IpAddressOriginCity = "Whitby",
                IpAddressOriginISP = "Rogers Communications",
                VpnDetected = false,
                ProxyDetected = false,
                TorDetected = false,
                HostingProviderDetected = false,
                NetworkType = "Home",

                GeoLatitude = 43.897,
                GeoLongitude = -78.942,
                GeoAccuracyMeters = 120,
                GeoCountry = "Canada",
                GeoCity = "Whitby",
                GeoRegion = "Ontario",

                TypingSpeedWPM = 42,
                MouseMovementPatternHash = null,
                TouchPressurePatternHash = "tp-3929ab",
                InteractionIntervalMs = 280,
                SuspiciousInteractionScore = 12,

                FirstAccessedAtUtc = DateTime.UtcNow.AddMinutes(-15),
                LastAccessedAtUtc = DateTime.UtcNow,
                SubmissionAttemptCount = 1,
                SubmissionCompletedAtUtc = null,
                SessionDurationSeconds = 900,
                SessionId = "sess-1a2b3c",
                SessionReused = false,

                RepeatedSubmissionDetected = false,
                DuplicateContentDetected = false,
                HighRiskPatternDetected = false,
                BlacklistHit = false,
                WhitelistHit = true,
                RiskScore = 8,
                RiskLevel = "Low",

                JavascriptEnabled = true,
                CookiesEnabled = true,
                LocalStorageEnabled = true,
                TimezoneOffset = -240,
                Language = "fr-CA",
                Platform = "iOS",
                ReferrerUrl = "",
                EntryUrl = "https://anti-corruption.gov/report"
            },

            // SAMPLE 2 — VPN + repeated attempts (medium risk)
            new IncidentSecurityDetail
            {
                Id = Guid.NewGuid(),
                IncidentRequestId = Guid.Parse("50000000-0000-0000-0000-000000000001"),

                DeviceId = "dev-7c1f8e",
                DeviceModel = "Samsung Galaxy S22",
                DeviceManufacturer = "Samsung",
                DeviceOS = "Android",
                DeviceOSVersion = "14",
                BrowserName = "Chrome",
                BrowserVersion = "126.0",
                UserAgentString = "Mozilla/5.0 (Linux; Android 14; SM-S901W)...",
                ScreenResolution = "1080x2340",
                IsMobileDevice = true,
                IsBotSuspected = false,

                IpAddress = "185.220.101.4",
                IpAddressOriginCountry = "Germany",
                IpAddressOriginCity = "Berlin",
                IpAddressOriginISP = "M247 Ltd",
                VpnDetected = true,
                ProxyDetected = false,
                TorDetected = false,
                HostingProviderDetected = true,
                NetworkType = "VPN",

                GeoLatitude = 52.520,
                GeoLongitude = 13.405,
                GeoAccuracyMeters = 5000,
                GeoCountry = "Germany",
                GeoCity = "Berlin",
                GeoRegion = "Berlin",

                TypingSpeedWPM = 55,
                MouseMovementPatternHash = null,
                TouchPressurePatternHash = "tp-9921aa",
                InteractionIntervalMs = 190,
                SuspiciousInteractionScore = 35,

                FirstAccessedAtUtc = DateTime.UtcNow.AddHours(-2),
                LastAccessedAtUtc = DateTime.UtcNow,
                SubmissionAttemptCount = 4,
                SubmissionCompletedAtUtc = null,
                SessionDurationSeconds = 7200,
                SessionId = "sess-9f8d1e",
                SessionReused = true,

                RepeatedSubmissionDetected = true,
                DuplicateContentDetected = false,
                HighRiskPatternDetected = false,
                BlacklistHit = false,
                WhitelistHit = false,
                RiskScore = 42,
                RiskLevel = "Medium",

                JavascriptEnabled = true,
                CookiesEnabled = true,
                LocalStorageEnabled = true,
                TimezoneOffset = 120,
                Language = "en-US",
                Platform = "Android",
                ReferrerUrl = "",
                EntryUrl = "https://anti-corruption.gov/report"
            },

            // SAMPLE 3 — TOR browser (critical risk)
            new IncidentSecurityDetail
            {
                Id = Guid.NewGuid(),
                IncidentRequestId = Guid.Parse("51000000-0000-0000-0000-000000000002"),

                DeviceId = "dev-tor-001",
                DeviceModel = "Unknown",
                DeviceManufacturer = "Unknown",
                DeviceOS = "Linux",
                DeviceOSVersion = "Unknown",
                BrowserName = "Tor Browser",
                BrowserVersion = "13.0",
                UserAgentString = "Mozilla/5.0 (X11; Linux x86_64; rv:102.0)...",
                ScreenResolution = "1920x1080",
                IsMobileDevice = false,
                IsBotSuspected = true,

                IpAddress = "185.220.100.255",
                IpAddressOriginCountry = "Unknown",
                IpAddressOriginCity = "Unknown",
                IpAddressOriginISP = "Tor Exit Node",
                VpnDetected = false,
                ProxyDetected = true,
                TorDetected = true,
                HostingProviderDetected = true,
                NetworkType = "Tor",

                GeoLatitude = null,
                GeoLongitude = null,
                GeoAccuracyMeters = null,
                GeoCountry = "Unknown",
                GeoCity = "Unknown",
                GeoRegion = "Unknown",

                TypingSpeedWPM = 12,
                MouseMovementPatternHash = "mm-0000",
                TouchPressurePatternHash = null,
                InteractionIntervalMs = 50,
                SuspiciousInteractionScore = 88,

                FirstAccessedAtUtc = DateTime.UtcNow.AddMinutes(-5),
                LastAccessedAtUtc = DateTime.UtcNow,
                SubmissionAttemptCount = 7,
                SubmissionCompletedAtUtc = null,
                SessionDurationSeconds = 300,
                SessionId = "sess-tor-001",
                SessionReused = true,

                RepeatedSubmissionDetected = true,
                DuplicateContentDetected = true,
                HighRiskPatternDetected = true,
                BlacklistHit = true,
                WhitelistHit = false,
                RiskScore = 95,
                RiskLevel = "Critical",

                JavascriptEnabled = false,
                CookiesEnabled = false,
                LocalStorageEnabled = false,
                TimezoneOffset = 0,
                Language = "en-US",
                Platform = "Linux",
                ReferrerUrl = "",
                EntryUrl = "https://anti-corruption.gov/report"
            },

            // SAMPLE 4 — Corporate network (low risk)
            new IncidentSecurityDetail
            {
                Id = Guid.NewGuid(),
                IncidentRequestId = Guid.Parse("51000000-0000-0000-0000-000000000003"),

                DeviceId = "dev-corp-77",
                DeviceModel = "Dell Latitude 7420",
                DeviceManufacturer = "Dell",
                DeviceOS = "Windows",
                DeviceOSVersion = "11 Pro",
                BrowserName = "Edge",
                BrowserVersion = "126.0",
                UserAgentString = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)...",
                ScreenResolution = "1920x1080",
                IsMobileDevice = false,
                IsBotSuspected = false,

                IpAddress = "64.18.12.44",
                IpAddressOriginCountry = "Canada",
                IpAddressOriginCity = "Toronto",
                IpAddressOriginISP = "Bell Canada",
                VpnDetected = false,
                ProxyDetected = false,
                TorDetected = false,
                HostingProviderDetected = false,
                NetworkType = "Corporate",

                GeoLatitude = 43.653,
                GeoLongitude = -79.383,
                GeoAccuracyMeters = 300,
                GeoCountry = "Canada",
                GeoCity = "Toronto",
                GeoRegion = "Ontario",

                TypingSpeedWPM = 72,
                MouseMovementPatternHash = "mm-9921",
                TouchPressurePatternHash = null,
                InteractionIntervalMs = 320,
                SuspiciousInteractionScore = 10,

                FirstAccessedAtUtc = DateTime.UtcNow.AddHours(-1),
                LastAccessedAtUtc = DateTime.UtcNow,
                SubmissionAttemptCount = 1,
                SubmissionCompletedAtUtc = null,
                SessionDurationSeconds = 3600,
                SessionId = "sess-corp-77",
                SessionReused = false,

                RepeatedSubmissionDetected = false,
                DuplicateContentDetected = false,
                HighRiskPatternDetected = false,
                BlacklistHit = false,
                WhitelistHit = true,
                RiskScore = 5,
                RiskLevel = "Low",

                JavascriptEnabled = true,
                CookiesEnabled = true,
                LocalStorageEnabled = true,
                TimezoneOffset = -240,
                Language = "en-CA",
                Platform = "Windows",
                ReferrerUrl = "",
                EntryUrl = "https://anti-corruption.gov/report"
            },

            // SAMPLE 5 — Public WiFi + proxy (high risk)
            new IncidentSecurityDetail
            {
                Id = Guid.NewGuid(),
                IncidentRequestId = Guid.Parse("51000000-0000-0000-0000-000000000005"),

                DeviceId = "dev-wifi-22",
                DeviceModel = "Huawei P30",
                DeviceManufacturer = "Huawei",
                DeviceOS = "Android",
                DeviceOSVersion = "12",
                BrowserName = "Chrome",
                BrowserVersion = "125.0",
                UserAgentString = "Mozilla/5.0 (Linux; Android 12; ELE-L29)...",
                ScreenResolution = "1080x2340",
                IsMobileDevice = true,
                IsBotSuspected = false,

                IpAddress = "172.16.0.22",
                IpAddressOriginCountry = "Canada",
                IpAddressOriginCity = "Ottawa",
                IpAddressOriginISP = "Public WiFi",
                VpnDetected = false,
                ProxyDetected = true,
                TorDetected = false,
                HostingProviderDetected = false,
                NetworkType = "Public WiFi",

                GeoLatitude = 45.421,
                GeoLongitude = -75.697,
                GeoAccuracyMeters = 1500,
                GeoCountry = "Canada",
                GeoCity = "Ottawa",
                GeoRegion = "Ontario",

                TypingSpeedWPM = 38,
                MouseMovementPatternHash = null,
                TouchPressurePatternHash = "tp-5511",
                InteractionIntervalMs = 210,
                SuspiciousInteractionScore = 65,

                FirstAccessedAtUtc = DateTime.UtcNow.AddMinutes(-30),
                LastAccessedAtUtc = DateTime.UtcNow,
                SubmissionAttemptCount = 3,
                SubmissionCompletedAtUtc = null,
                SessionDurationSeconds = 1800,
                SessionId = "sess-wifi-22",
                SessionReused = true,

                RepeatedSubmissionDetected = true,
                DuplicateContentDetected = false,
                HighRiskPatternDetected = true,
                BlacklistHit = false,
                WhitelistHit = false,
                RiskScore = 78,
                RiskLevel = "High",

                JavascriptEnabled = true,
                CookiesEnabled = true,
                LocalStorageEnabled = true,
                TimezoneOffset = -240,
                Language = "fr-CA",
                Platform = "Android",
                ReferrerUrl = "",
                EntryUrl = "https://anti-corruption.gov/report"
            }
        };
        }
    }

}
