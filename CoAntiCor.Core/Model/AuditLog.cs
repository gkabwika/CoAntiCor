
using CoAntiCor.Core.Domain;

namespace CoAntiCor.Core.Model
{
    /// <summary>
    /// 2. Full audit log model for regulator inspections
    /// Complaint history is case-specific.Regulators also need a system-wide, immutable audit trail for:
    /// - Logins, failed logins
    /// - Role changes
    /// - Data exports
    /// - Status changes
    /// - Assignments
    /// - Configuration changes
    /// 2.1. Audit log entity

    /// </summary>
    public class AuditLog : EntityBaseObject
    {     
        public DateTime TimestampUtc { get; set; }

        public Guid? UserId { get; set; }
        public string? UserName { get; set; }

        public AuditActionType ActionType { get; set; }

        public string? EntityType { get; set; }      // e.g. "Complaint", "User"
        public string? EntityId { get; set; }        // e.g. complaint GUID, user GUID

        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }

        public string? Summary { get; set; }         // human-readable summary
        public string? DetailsJson { get; set; }     // structured JSON payload
    }

}
