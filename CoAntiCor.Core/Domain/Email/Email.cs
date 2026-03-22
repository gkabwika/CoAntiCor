using CoAntiCor.Core.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoAntiCor.Core.Domain.Email
{
    public class Email : EntityBaseObject
    {      
        [MaxLength(10)] //Hardening XXX change to 256
        public string EmailCode { get; set; }
        public int ServiceRequestNumber { get; set; } //Hardening XXX  not needed
        public int VersionNum { get; set; } //Hardening XXX not needed        
        public Guid EmailTemplateId { get; set; }

        [ForeignKey("EmailTemplateId")]
        public EmailTemplate? EmailTemplate { get; set; }
        public int Status { get; set; } //Hardening XXX change to emailStatus, add Code Table

        [MaxLength(4096)]
        public string EmailTo { get; set; }
        [MaxLength(4096)]
        public string? EmailCC { get; set; }
        [MaxLength(4096)]
        public string? EmailBCC { get; set; }
        [MaxLength(512)]
        public string Subject { get; set; }
        [MaxLength(4096)]
        public string? Body { get; set; }
        [MaxLength(256)]
        public string SenderEmail { get; set; }
        public ICollection<EmailAttachment> EmailAttachments { get; set; } = new List<EmailAttachment>();
    }
}
