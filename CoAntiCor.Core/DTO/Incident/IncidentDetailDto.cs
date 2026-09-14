using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.DTO.Incident
{
    namespace CoAntiCor.Core.DTO.Incident
    {
        public class IncidentDetailDto
        {
            public Guid Id { get; set; }
            public Guid IncidentRequestId { get; set; }

            // Victim / Witness
            public string? VictimDescription { get; set; }
            public bool VictimLifeInDanger { get; set; }

            // Corruption statements
            public bool HasCorruptionStatements { get; set; }
            public string? DepartmentInvolved { get; set; }
            public string? PlannedFacts { get; set; }

            // Officials involved
            public string? PrimaryOfficial { get; set; }
            public string? SecondaryOfficial { get; set; }
            public string? OtherOfficial { get; set; }

            // Incident details
            public DateTime? IncidentDate { get; set; }
            public string? CurrencyType { get; set; }
            public decimal? ApproxAmount { get; set; }

            // Payment / corruption behavior flags
            public bool ReasonForPayment { get; set; }
            public bool PaymentMadeBefore { get; set; }
            public bool AggressiveBehaviorObserved { get; set; }
            public bool IncreasedMotivationOrInterest { get; set; }
            public bool IntimidationObserved { get; set; }

            // Payment reason details
            public string? PaymentReasonDescription { get; set; }
            public string? PaymentReasonType { get; set; }
            public int? PaymentReasonFrequency { get; set; }

            // Aggressive behavior details
            public string? AggressiveBehaviorDescription { get; set; }
            public string? AggressiveBehaviorDuration { get; set; }
            public int? AggressiveBehaviorFrequency { get; set; }

            // Favoring factors
            public bool TemperamentOptimism { get; set; }
            public bool CorruptionDiscreetlyCompleted { get; set; }
            public bool HasPaidAgentBefore { get; set; }
            public bool CorruptionWithConfidence { get; set; }
            public bool AttachmentToCorruptionMethods { get; set; }
            public bool SimilarCorruptionExists { get; set; }

            // Attachments
            public string? AttachmentExplanation { get; set; }
            public string? AttachmentChoice { get; set; } // Original / NonOriginal / None
            public string? DocumentName { get; set; }
            public bool IsCurrentDocument { get; set; }
            public string? DocumentPath { get; set; }
            public bool SecurityAcknowledged { get; set; }
        }
    }

}
