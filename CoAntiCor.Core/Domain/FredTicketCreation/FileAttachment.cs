using CoAntiCor.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace CoAntiCor.Core.Domain.FredTicketCreation
{
    public class FileAttachment : BaseObject
    {
        [Key]
        public Guid ID { get; set; }
        public string FileName { get; set; } = string.Empty;
        public long Size { get; set; }
        // public DateTime DateModified { get; set; } = DateTime.Now;
        public bool Viewed { get; set; } = false;
        public Guid FredRequestID { get; set; }
        public FredRequest FredRequest { get; set; } = default!;
    }
}
