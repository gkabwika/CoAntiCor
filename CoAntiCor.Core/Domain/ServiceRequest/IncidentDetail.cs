using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Domain.ServiceRequest
{
    public class IncidentDetail : EntityBaseObject
    {
        public new Guid Id { get; set; }
        public Guid IncidentRequestId { get; set; }

        // Éducation
        public string? EducationLevel { get; set; }

        // Type de cas
        public Guid? IncidentCategoryId { get; set; }
        public string? IncidentCategoryName { get; set; }

        // Partie 1 : Victime ou témoin
        public bool VictimProvidesName { get; set; }
        public string? VictimDescription { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public string? Commune { get; set; }
        public string? Quartier { get; set; }
        public string? Address { get; set; }
        public bool HasPrivateOrganizationInvolved { get; set; }

        // Partie 2 : Description des problématiques de corruption
        public bool HasCorruptionStatements { get; set; }
        public string? DepartmentInvolved { get; set; }
        public string? PlannedFacts { get; set; }
        public string? PrimaryOfficial { get; set; }
        public string? SecondaryOfficial { get; set; }
        public string? OtherOfficial { get; set; }
        public DateTime? IncidentDate { get; set; }
        public string? CurrencyType { get; set; }
        public decimal? ApproxAmount { get; set; }

        public bool VictimLifeInDanger { get; set; }
        public bool ReasonForPayment { get; set; }
        public bool PaymentMadeBefore { get; set; }
        public bool AggressiveBehaviorObserved { get; set; }
        public bool IncreasedMotivationOrInterest { get; set; }
        public bool IntimidationObserved { get; set; }

        // Descriptions détaillées
        public string? PaymentReasonDescription { get; set; }
        public string? PaymentReasonType { get; set; }
        public int? PaymentReasonFrequency { get; set; }

        public string? AggressiveBehaviorDescription { get; set; }
        public string? AggressiveBehaviorDuration { get; set; }
        public int? AggressiveBehaviorFrequency { get; set; }

        // Partie 3 : Facteurs favorisant le corrupteur
        public bool TemperamentOptimism { get; set; }
        public bool CorruptionDiscreetlyCompleted { get; set; }
        public bool HasPaidAgentBefore { get; set; }
        public bool CorruptionWithConfidence { get; set; }
        public bool AttachmentToCorruptionMethods { get; set; }
        public bool SimilarCorruptionExists { get; set; }

        // Partie 4 : Pièces jointes
        public string? AttachmentExplanation { get; set; }
        public string? AttachmentChoice { get; set; } // "Original", "NonOriginal", "None"
        public string? DocumentName { get; set; }
        public bool IsCurrentDocument { get; set; }
        public string? DocumentPath { get; set; }
        public bool SecurityAcknowledged { get; set; }
    }

}
