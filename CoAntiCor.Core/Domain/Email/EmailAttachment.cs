using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoAntiCor.Core.Domain.Email
{
    // EmailAttachment.cs
    public class EmailAttachment : EntityBaseObject
    {
        public string? FileName { get; set; }
        public Guid? EmailId { get; set; }
        [ForeignKey("EmailId")]
        public Email? Email { get; set; }
    }
}
