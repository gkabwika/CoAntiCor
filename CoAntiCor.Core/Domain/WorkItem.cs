
using CoAntiCor.Core.Model;
using CoAntiCor.Data.Entities;

namespace CoAntiCor.Core.Domain
{
    public class WorkItem :  EntityBaseObject
    {
        public Guid CompanyRequestId { get; set; }
        public ServiceRequest ServiceRequest { get; set; } = default!;
        public string AssignedToUserId { get; set; } = default!;
        public ComplaintStatus Status { get; set; }
        public string? Comments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public ICollection<ProcessingPhase> Phases { get; set; } = new List<ProcessingPhase>();
    }
}
