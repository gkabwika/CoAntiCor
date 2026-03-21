
namespace CoAntiCor.Core.Model
{
    public class ChangeStatusRequest
    {
        public ComplaintStatus NewStatus { get; set; }
        public string? Comment { get; set; }
    }


}
