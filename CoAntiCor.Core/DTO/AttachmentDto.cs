
namespace CoAntiCor.Core.DTO
{
    public class AttachmentDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}