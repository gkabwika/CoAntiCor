
namespace CoAntiCor.Core.DTO
{
    public class ComplaintDraftListItemDto
    {
        public Guid DraftId { get; set; }
        public int CurrentStep { get; set; }
        public DateTime LastUpdatedUtc { get; set; }
    }
}
