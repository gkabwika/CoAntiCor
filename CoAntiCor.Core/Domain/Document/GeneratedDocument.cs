using CoAntiCor.Core.Domain;

namespace CoAntiCor.Core.Domain.Document
{
    public class GeneratedDocument : EntityBaseObject
    {
        public Guid ComplaintId { get; set; }
        public Complaint Complaint { get; set; } = default!;
        public string DocumentType { get; set; } = default!; // RCCM, TaxCertificate, ONEM, CNSS
        public string FilePath { get; set; } = default!;
        public DateTime GeneratedAt { get; set; }
        public string SignatureAuthority { get; set; } = default!;
    }

}
