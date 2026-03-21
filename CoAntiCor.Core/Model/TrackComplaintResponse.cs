
namespace CoAntiCor.Core.Model
{
    public class TrackComplaintResponse
    {
        public string ComplaintNumber { get; set; } = default!;
        public ComplaintStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public string? LastPublicComment { get; set; }
    }

}
