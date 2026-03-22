using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoAntiCor.Core.Domain.Email
{
    // EmailExecution.cs
    public class EmailExecution : EntityBaseObject
    {               
        [MaxLength(20)]
        public string? Status { get; set; }
        [MaxLength(4096)]
        public string? ExecutionStep { get; set; }               
        public DateTime? SentDateTime { get; set; }
        public DateTime? LastAttemptDateTime { get; set; }
        [MaxLength(4096)]
        public string? Notes { get; set; }
        public Guid? EmailId { get; set; }
        [ForeignKey("EmailId")]
        public Email? Email { get; set; }
    }
}
