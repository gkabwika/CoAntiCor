
namespace CoAntiCor.Core.Model
{
    public class DraftSaveResult
    {
        public bool Success { get; set; }
        public bool Conflict { get; set; }
        public string? ServerStateJson { get; set; }
        public int? ServerVersion { get; set; }
    }
}
