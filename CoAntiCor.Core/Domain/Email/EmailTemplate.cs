using System.ComponentModel.DataAnnotations;

namespace CoAntiCor.Core.Domain.Email
{
    // EmailTemplate.cs
    public class EmailTemplate : EntityBaseObject
    {
        [MaxLength(6)]
        public string Product { get; set; }
        [MaxLength(10)]
        public string EmailCode { get; set; }
        [MaxLength(4096)]
        public string EmailTo { get; set; }
        [MaxLength(4096)]
        public string? EmailCC { get; set; }
        [MaxLength(4096)]
        public string? EmailBCC { get; set; }
        [MaxLength(512)]
        public string Subject { get; set; }
        [MaxLength(4096)]
        public string Body { get; set; }
        [MaxLength(256)]
        public string SenderEmail { get; set; }      

    }
}
