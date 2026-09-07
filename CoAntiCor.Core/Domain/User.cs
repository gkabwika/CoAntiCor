using CoAntiCor.Core.Domain.ServiceRequest;

namespace CoAntiCor.Core.Domain
{
    public class User:EntityBaseObject
    {
        public new Guid Id { get; set; }

        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? PhoneNumber { get; set; }

        public bool IsInternal { get; set; }
        public bool IsAnonymous { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<Complaint> ComplaintsInitiated { get; set; } = new List<Complaint>();
        public ICollection<IncidentRequest> IncidentRequestInitiated { get; set; } = new List<IncidentRequest>();
        public ICollection<ProcessingPhase> AssignedPhases { get; set; } = new List<ProcessingPhase>();
    }
}
