using CoAntiCor.Core.Domain.FredTicketCreation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Domain
{
    public class ComplaintAttachment : EntityBaseObject
    {     
        public Guid ComplaintId { get; set; }
        public Complaint Complaint { get; set; } = default!;
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
