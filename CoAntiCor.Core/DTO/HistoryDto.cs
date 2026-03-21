using CoAntiCor.Core.Model;

namespace CoAntiCor.Core.DTO
{
    public class HistoryDto
    {
        public DateTime ChangedAt { get; set; }
        public ComplaintStatus OldStatus { get; set; }
        public ComplaintStatus NewStatus { get; set; }
        public string ChangedBy { get; set; }
        public string Comment { get; set; }
    }
}