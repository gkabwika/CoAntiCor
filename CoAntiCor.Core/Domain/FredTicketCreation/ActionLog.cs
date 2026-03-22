using CoAntiCor.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace CoAntiCor.Core.Domain.FredTicketCreation
{
    public class ActionLog : BaseObject
    {
        [Key]
        public Guid ID { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string UserName { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid FredRequestID { get; set; }
        public FredRequest FredRequest { get; set; } = default!;
    }
}
