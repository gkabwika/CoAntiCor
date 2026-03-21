
namespace CoAntiCor.Core.Domain
{
    public class AttachmentDraftItem
    {
        public string TempId { get; set; } = default!;
        public string FileName { get; set; } = default!;
        public long Size { get; set; }
        public string OriginalFileName { get; set; } = default!;
        public string StoredFileName { get; set; } = default!;
        public string FileType { get; set; } = default!;
        public long FileSize { get; set; }
        public string StoragePath { get; set; } = default!; // or BlobUri
        public string ContentType { get; set; } = default!;
        public DateTime UploadedAt { get; set; }
    }
}
