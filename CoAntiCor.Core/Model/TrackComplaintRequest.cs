namespace CoAntiCor.Core.Model
{
    public class TrackComplaintRequest
    {
        public string ComplaintNumber { get; set; } = default!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }

}
