using CoAntiCor.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace CoAntiCor.Core.Domain.FredTicketCreation
{ 
    public class FredRequestFile : BaseObject
    {
        [Key]
        public Guid ID { get; set; }
        public Guid FredRequestID { get; set; }
        public FredRequest Request { get; set; } = default!;
        public string OriginalFileName { get; set; } = default!;
        public string StoredFileName { get; set; } = default!;
        public string ContentType { get; set; } = default!;
        public long FileSizeBytes { get; set; }
        public string StoredPath { get; set; } = default!;
        public bool Viewed { get; set; } = false;
        public DateTime UploadedUtc { get; set; }
    }

}
