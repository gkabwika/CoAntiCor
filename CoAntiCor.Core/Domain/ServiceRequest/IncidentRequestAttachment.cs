
namespace CoAntiCor.Core.Domain.ServiceRequest
{
    public class IncidentRequestAttachment : EntityBaseObject
    {     
        public Guid IncidentRequestId { get; set; }
        public IncidentRequest IncidentRequest { get; set; } = default!;
        public bool IsOfficialEvidence { get; set; } = false;
        public string EvidenceByOfficialUser { get; set; } = default!;

        public string FileName { get; set; } = default!;
        public string OriginalFileName { get; set; } = default!;
        public string StoredFileName { get; set; } = default!;
        public string FileType { get; set; } = default!;
        public long FileSize { get; set; }
        public string StoragePath { get; set; } = default!; // or BlobUri
        public string ContentType { get; set; } = default!;
        public bool Viewed { get; set; } = false;
        public DateTime UploadedAt { get; set; }
    }
}
