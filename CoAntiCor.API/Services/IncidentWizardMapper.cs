using CoAntiCor.Core.Domain.ServiceRequest;
using CoAntiCor.Core.DTO.Incident;
using CoAntiCor.Core.DTO.Incident.CoAntiCor.Core.DTO.Incident;

namespace CoAntiCor.API.Services
{
    public static class IncidentWizardMapper
    {
        public static WizardDraftState ToWizardDraftState(IncidentRequest request)
        {
            return new WizardDraftState
            {
                DraftId = request?.DraftId ?? Guid.Empty,
                CurrentStep = request?.CurrentStep??0,
                Version = request?.Version??0,
                IsAnonymous = request?.IsAnonymous??true,

                IncidentRequest = new IncidentRequestDto
                {
                    Id = request!.Id,
                    Title = request.Title,
                    ShortDescription = request.ShortDescription,
                    // ...
                },
                IncidentDetail = new IncidentDetailDto
                {
                    IncidentRequestId = request.Id,
                    VictimDescription = request.IncidentDetail?.VictimDescription,
                    HasCorruptionStatements = request.IncidentDetail?.HasCorruptionStatements ?? false,
                    // map all IncidentDetail fields…
                },
                SecurityDetail = new IncidentSecurityDetailDto
                {
                    IncidentRequestId = request.Id,
                    IpAddress = request.SecurityDetail?.IpAddress,
                    BrowserName = request.SecurityDetail?.BrowserName,
                    RiskScore = request.SecurityDetail?.RiskScore ?? 0,
                    // map all IncidentSecurityDetail fields…
                }
            };
        }

        public static IncidentRequest ToIncidentRequest(WizardDraftState state)
        {
            var request = new IncidentRequest
            {
                Id = Guid.NewGuid(),
                DraftId = state.DraftId,
                CurrentStep = state.CurrentStep,
                Version = state.Version,
                IsAnonymous = state.IsAnonymous,
                Title = state.IncidentRequest.Title,
                ShortDescription = state.IncidentRequest.ShortDescription,
                // ...
                IncidentDetail = ToIncidentDetail(state),
                SecurityDetail = ToIncidentSecurityDetail(state)
            };

            return request;
        }

        public static void UpdateIncidentRequest(IncidentRequest request, WizardDraftState state)
        {
            request.CurrentStep = state.CurrentStep;
            request.Version = state.Version;
            request.IsAnonymous = state.IsAnonymous;

            request.Title = state.IncidentRequest.Title;
            request.ShortDescription = state.IncidentRequest.ShortDescription;
            // ...

            if (request.IncidentDetail == null)
                request.IncidentDetail= ToIncidentDetail(state);
            else
                UpdateIncidentDetail(request.IncidentDetail, state);

            if (request.SecurityDetail == null)
                request.SecurityDetail = ToIncidentSecurityDetail(state);
            else
                UpdateIncidentSecurityDetail(request.SecurityDetail, state);
        }

        public static IncidentDetail ToIncidentDetail(WizardDraftState state)
        {
            return new IncidentDetail
            {
                Id = Guid.NewGuid(),
                IncidentRequestId = state.IncidentRequest.Id,
                VictimDescription = state.IncidentDetail.VictimDescription,
                HasCorruptionStatements = state.IncidentDetail.HasCorruptionStatements,
                DepartmentInvolved = state.IncidentDetail.DepartmentInvolved,
                PlannedFacts = state.IncidentDetail.PlannedFacts,
                PrimaryOfficial = state.IncidentDetail.PrimaryOfficial,
                SecondaryOfficial = state.IncidentDetail.SecondaryOfficial,
                OtherOfficial = state.IncidentDetail.OtherOfficial,
                IncidentDate = state.IncidentDetail.IncidentDate,
                CurrencyType = state.IncidentDetail.CurrencyType,
                ApproxAmount = state.IncidentDetail.ApproxAmount,
                VictimLifeInDanger = state.IncidentDetail.VictimLifeInDanger,
                ReasonForPayment = state.IncidentDetail.ReasonForPayment,
                PaymentMadeBefore = state.IncidentDetail.PaymentMadeBefore,
                AggressiveBehaviorObserved = state.IncidentDetail.AggressiveBehaviorObserved,
                IncreasedMotivationOrInterest = state.IncidentDetail.IncreasedMotivationOrInterest,
                IntimidationObserved = state.IncidentDetail.IntimidationObserved,
                PaymentReasonDescription = state.IncidentDetail.PaymentReasonDescription,
                PaymentReasonType = state.IncidentDetail.PaymentReasonType,
                PaymentReasonFrequency = state.IncidentDetail.PaymentReasonFrequency,
                AggressiveBehaviorDescription = state.IncidentDetail.AggressiveBehaviorDescription,
                AggressiveBehaviorDuration = state.IncidentDetail.AggressiveBehaviorDuration,
                AggressiveBehaviorFrequency = state.IncidentDetail.AggressiveBehaviorFrequency,
                TemperamentOptimism = state.IncidentDetail.TemperamentOptimism,
                CorruptionDiscreetlyCompleted = state.IncidentDetail.CorruptionDiscreetlyCompleted,
                HasPaidAgentBefore = state.IncidentDetail.HasPaidAgentBefore,
                CorruptionWithConfidence = state.IncidentDetail.CorruptionWithConfidence,
                AttachmentToCorruptionMethods = state.IncidentDetail.AttachmentToCorruptionMethods,
                SimilarCorruptionExists = state.IncidentDetail.SimilarCorruptionExists,
                AttachmentExplanation = state.IncidentDetail.AttachmentExplanation,
                AttachmentChoice = state.IncidentDetail.AttachmentChoice,
                DocumentName = state.IncidentDetail.DocumentName,
                IsCurrentDocument = state.IncidentDetail.IsCurrentDocument,
                DocumentPath = state.IncidentDetail.DocumentPath,
                SecurityAcknowledged = state.IncidentDetail.SecurityAcknowledged
            };
        }

        public static void UpdateIncidentDetail(IncidentDetail detail, WizardDraftState state)
        {
            detail.VictimDescription = state.IncidentDetail.VictimDescription;
            detail.HasCorruptionStatements = state.IncidentDetail.HasCorruptionStatements;
            detail.DepartmentInvolved = state.IncidentDetail.DepartmentInvolved;
            detail.PlannedFacts = state.IncidentDetail.PlannedFacts;
            detail.PrimaryOfficial = state.IncidentDetail.PrimaryOfficial;
            detail.SecondaryOfficial = state.IncidentDetail.SecondaryOfficial;
            detail.OtherOfficial = state.IncidentDetail.OtherOfficial;
            detail.IncidentDate = state.IncidentDetail.IncidentDate;
            detail.CurrencyType = state.IncidentDetail.CurrencyType;
            detail.ApproxAmount = state.IncidentDetail.ApproxAmount;
            detail.VictimLifeInDanger = state.IncidentDetail.VictimLifeInDanger;
            detail.ReasonForPayment = state.IncidentDetail.ReasonForPayment;
            detail.PaymentMadeBefore = state.IncidentDetail.PaymentMadeBefore;
            detail.AggressiveBehaviorObserved = state.IncidentDetail.AggressiveBehaviorObserved;
            detail.IncreasedMotivationOrInterest = state.IncidentDetail.IncreasedMotivationOrInterest;
            detail.IntimidationObserved = state.IncidentDetail.IntimidationObserved;
            detail.PaymentReasonDescription = state.IncidentDetail.PaymentReasonDescription;
            detail.PaymentReasonType = state.IncidentDetail.PaymentReasonType;
            detail.PaymentReasonFrequency = state.IncidentDetail.PaymentReasonFrequency;
            detail.AggressiveBehaviorDescription = state.IncidentDetail.AggressiveBehaviorDescription;
            detail.AggressiveBehaviorDuration = state.IncidentDetail.AggressiveBehaviorDuration;
            detail.AggressiveBehaviorFrequency = state.IncidentDetail.AggressiveBehaviorFrequency;
            detail.TemperamentOptimism = state.IncidentDetail.TemperamentOptimism;
            detail.CorruptionDiscreetlyCompleted = state.IncidentDetail.CorruptionDiscreetlyCompleted;
            detail.HasPaidAgentBefore = state.IncidentDetail.HasPaidAgentBefore;
            detail.CorruptionWithConfidence = state.IncidentDetail.CorruptionWithConfidence;
            detail.AttachmentToCorruptionMethods = state.IncidentDetail.AttachmentToCorruptionMethods;
            detail.SimilarCorruptionExists = state.IncidentDetail.SimilarCorruptionExists;
            detail.AttachmentExplanation = state.IncidentDetail.AttachmentExplanation;
            detail.AttachmentChoice = state.IncidentDetail.AttachmentChoice;
            detail.DocumentName = state.IncidentDetail.DocumentName;
            detail.IsCurrentDocument = state.IncidentDetail.IsCurrentDocument;
            detail.DocumentPath = state.IncidentDetail.DocumentPath;
            detail.SecurityAcknowledged = state.IncidentDetail.SecurityAcknowledged;
        }

        public static IncidentSecurityDetail ToIncidentSecurityDetail(WizardDraftState state)
        {
            return new IncidentSecurityDetail
            {
                Id = Guid.NewGuid(),
                IncidentRequestId = state.IncidentRequest.Id,
                DeviceId = state.SecurityDetail.DeviceId,
                DeviceModel = state.SecurityDetail.DeviceModel,
                DeviceManufacturer = state.SecurityDetail.DeviceManufacturer,
                DeviceOS = state.SecurityDetail.DeviceOS,
                DeviceOSVersion = state.SecurityDetail.DeviceOSVersion,
                BrowserName = state.SecurityDetail.BrowserName,
                BrowserVersion = state.SecurityDetail.BrowserVersion,
                UserAgentString = state.SecurityDetail.UserAgentString,
                ScreenResolution = state.SecurityDetail.ScreenResolution,
                IsMobileDevice = state.SecurityDetail.IsMobileDevice,
                IsBotSuspected = state.SecurityDetail.IsBotSuspected,
                IpAddress = state.SecurityDetail.IpAddress,
                IpAddressOriginCountry = state.SecurityDetail.IpAddressOriginCountry,
                IpAddressOriginCity = state.SecurityDetail.IpAddressOriginCity,
                IpAddressOriginISP = state.SecurityDetail.IpAddressOriginISP,
                VpnDetected = state.SecurityDetail.VpnDetected,
                ProxyDetected = state.SecurityDetail.ProxyDetected,
                TorDetected = state.SecurityDetail.TorDetected,
                HostingProviderDetected = state.SecurityDetail.HostingProviderDetected,
                NetworkType = state.SecurityDetail.NetworkType,
                GeoLatitude = state.SecurityDetail.GeoLatitude,
                GeoLongitude = state.SecurityDetail.GeoLongitude,
                GeoAccuracyMeters = state.SecurityDetail.GeoAccuracyMeters,
                GeoCountry = state.SecurityDetail.GeoCountry,
                GeoCity = state.SecurityDetail.GeoCity,
                GeoRegion = state.SecurityDetail.GeoRegion,
                TypingSpeedWPM = state.SecurityDetail.TypingSpeedWPM,
                MouseMovementPatternHash = state.SecurityDetail.MouseMovementPatternHash,
                TouchPressurePatternHash = state.SecurityDetail.TouchPressurePatternHash,
                InteractionIntervalMs = state.SecurityDetail.InteractionIntervalMs,
                SuspiciousInteractionScore = state.SecurityDetail.SuspiciousInteractionScore,
                FirstAccessedAtUtc = state.SecurityDetail.FirstAccessedAtUtc,
                LastAccessedAtUtc = state.SecurityDetail.LastAccessedAtUtc,
                SubmissionAttemptCount = state.SecurityDetail.SubmissionAttemptCount,
                SubmissionCompletedAtUtc = state.SecurityDetail.SubmissionCompletedAtUtc,
                SessionDurationSeconds = state.SecurityDetail.SessionDurationSeconds,
                SessionId = state.SecurityDetail.SessionId,
                SessionReused = state.SecurityDetail.SessionReused,
                RepeatedSubmissionDetected = state.SecurityDetail.RepeatedSubmissionDetected,
                DuplicateContentDetected = state.SecurityDetail.DuplicateContentDetected,
                HighRiskPatternDetected = state.SecurityDetail.HighRiskPatternDetected,
                BlacklistHit = state.SecurityDetail.BlacklistHit,
                WhitelistHit = state.SecurityDetail.WhitelistHit,
                RiskScore = state.SecurityDetail.RiskScore,
                RiskLevel = state.SecurityDetail.RiskLevel,
                JavascriptEnabled = state.SecurityDetail.JavascriptEnabled,
                CookiesEnabled = state.SecurityDetail.CookiesEnabled,
                LocalStorageEnabled = state.SecurityDetail.LocalStorageEnabled,
                TimezoneOffset = state.SecurityDetail.TimezoneOffset,
                Language = state.SecurityDetail.Language,
                Platform = state.SecurityDetail.Platform,
                ReferrerUrl = state.SecurityDetail.ReferrerUrl,
                EntryUrl = state.SecurityDetail.EntryUrl
            };
        }

        public static void UpdateIncidentSecurityDetail(IncidentSecurityDetail entity, WizardDraftState state)
        {
            entity.DeviceId = state.SecurityDetail.DeviceId;
            entity.DeviceModel = state.SecurityDetail.DeviceModel;
            entity.DeviceManufacturer = state.SecurityDetail.DeviceManufacturer;
            entity.DeviceOS = state.SecurityDetail.DeviceOS;
            entity.DeviceOSVersion = state.SecurityDetail.DeviceOSVersion;
            entity.BrowserName = state.SecurityDetail.BrowserName;
            entity.BrowserVersion = state.SecurityDetail.BrowserVersion;
            entity.UserAgentString = state.SecurityDetail.UserAgentString;
            entity.ScreenResolution = state.SecurityDetail.ScreenResolution;
            entity.IsMobileDevice = state.SecurityDetail.IsMobileDevice;
            entity.IsBotSuspected = state.SecurityDetail.IsBotSuspected;
            entity.IpAddress = state.SecurityDetail.IpAddress;
            entity.IpAddressOriginCountry = state.SecurityDetail.IpAddressOriginCountry;
            entity.IpAddressOriginCity = state.SecurityDetail.IpAddressOriginCity;
            entity.IpAddressOriginISP = state.SecurityDetail.IpAddressOriginISP;
            entity.VpnDetected = state.SecurityDetail.VpnDetected;
            entity.ProxyDetected = state.SecurityDetail.ProxyDetected;
            entity.TorDetected = state.SecurityDetail.TorDetected;
            entity.HostingProviderDetected = state.SecurityDetail.HostingProviderDetected;
            entity.NetworkType = state.SecurityDetail.NetworkType;
            entity.GeoLatitude = state.SecurityDetail.GeoLatitude;
            entity.GeoLongitude = state.SecurityDetail.GeoLongitude;
            entity.GeoAccuracyMeters = state.SecurityDetail.GeoAccuracyMeters;
            entity.GeoCountry = state.SecurityDetail.GeoCountry;
            entity.GeoCity = state.SecurityDetail.GeoCity;
            entity.GeoRegion = state.SecurityDetail.GeoRegion;
            entity.TypingSpeedWPM = state.SecurityDetail.TypingSpeedWPM;
            entity.MouseMovementPatternHash = state.SecurityDetail.MouseMovementPatternHash;
            entity.TouchPressurePatternHash = state.SecurityDetail.TouchPressurePatternHash;
            entity.InteractionIntervalMs = state.SecurityDetail.InteractionIntervalMs;
            entity.SuspiciousInteractionScore = state.SecurityDetail.SuspiciousInteractionScore;
            entity.FirstAccessedAtUtc = state.SecurityDetail.FirstAccessedAtUtc;
            entity.LastAccessedAtUtc = state.SecurityDetail.LastAccessedAtUtc;
            entity.SubmissionAttemptCount = state.SecurityDetail.SubmissionAttemptCount;
            entity.SubmissionCompletedAtUtc = state.SecurityDetail.SubmissionCompletedAtUtc;
            entity.SessionDurationSeconds = state.SecurityDetail.SessionDurationSeconds;
            entity.SessionId = state.SecurityDetail.SessionId;
            entity.SessionReused = state.SecurityDetail.SessionReused;
            entity.RepeatedSubmissionDetected = state.SecurityDetail.RepeatedSubmissionDetected;
            entity.DuplicateContentDetected = state.SecurityDetail.DuplicateContentDetected;
            entity.HighRiskPatternDetected = state.SecurityDetail.HighRiskPatternDetected;
            entity.BlacklistHit = state.SecurityDetail.BlacklistHit;
            entity.WhitelistHit = state.SecurityDetail.WhitelistHit;
            entity.RiskScore = state.SecurityDetail.RiskScore;
            entity.RiskLevel = state.SecurityDetail.RiskLevel;
            entity.JavascriptEnabled = state.SecurityDetail.JavascriptEnabled;
            entity.CookiesEnabled = state.SecurityDetail.CookiesEnabled;
            entity.LocalStorageEnabled = state.SecurityDetail.LocalStorageEnabled;
            entity.TimezoneOffset = state.SecurityDetail.TimezoneOffset;
            entity.Language = state.SecurityDetail.Language;
            entity.Platform = state.SecurityDetail.Platform;
            entity.ReferrerUrl = state.SecurityDetail.ReferrerUrl;
            entity.EntryUrl = state.SecurityDetail.EntryUrl;
        }
    }

}
