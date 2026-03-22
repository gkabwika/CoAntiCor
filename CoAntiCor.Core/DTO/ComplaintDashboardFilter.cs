using CoAntiCor.Core.Model;

namespace CoAntiCor.Core.DTO
{
    public class ComplaintDashboardFilter
    {
        public string? Province { get; set; }
        public string? City { get; set; }
        public Guid? IncidentTypeId { get; set; }
        public Guid? IncidentCategoryId { get; set; }
        public ComplaintStatus? Status { get; set; }
        public Guid? AssignedToUserId { get; set; }
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
