
using CoAntiCor.Core.Domain;

namespace CoAntiCor.Core.Domain.Organization.PaymentInfo
{    
    public class PaymentLog : EntityBaseObject
    {
        public int? PaymentId { get; set; }
        public string LogMessage { get; set; } = string.Empty;     
        public DateTime? TimeStamp { get; set; } = DateTime.Now;      
    }
}