using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Domain
{
    /// <summary>
    /// TenantAudit system (logs Tenant, Province, User, Office, IP, Action, Entity)
    /// </summary>
    public class TenantAuditEntry :EntityBaseObject
    {
        public new Guid Id { get; set; } = Guid.NewGuid();
        public DateTime TimestampUtc { get; set; } = DateTime.UtcNow;

        public Guid? UserId { get; set; }
        public Guid? BrokerOfficeId { get; set; }
        public string? ProvinceCode { get; set; }

        public string? IpAddress { get; set; }
        public string? ActionName { get; set; }
        public string? ControllerName { get; set; }
        public string? EntityName { get; set; }
        public string? EntityId { get; set; }
        public string? DetailsJson { get; set; }
    }
}
