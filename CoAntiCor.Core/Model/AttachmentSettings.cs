
namespace CoAntiCor.Core.Model
{
    public class AttachmentSettings
    {
        public string TempFolder { get; set; } = "uploads/temp";
        public string PermanentFolder { get; set; } = "uploads/complaints";
        public long MaxFileSizeBytes { get; set; } = 20 * 1024 * 1024; // 20 MB
        public string[] AllowedContentTypes { get; set; } =
        {
        "image/jpeg",
        "image/png",
        "application/pdf",
        "video/mp4",
        "audio/mpeg",
        "audio/wav"
    };
    }
}
