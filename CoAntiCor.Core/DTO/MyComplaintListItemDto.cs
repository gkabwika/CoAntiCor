using CoAntiCor.Core.Model;

namespace CoAntiCor.Core.DTO
{
    public class MyComplaintListItemDto
    {
        public Guid Id { get; set; }
        public string ComplaintNumber { get; set; } = default!;
        public string Title { get; set; } = default!;
        public ComplaintStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
