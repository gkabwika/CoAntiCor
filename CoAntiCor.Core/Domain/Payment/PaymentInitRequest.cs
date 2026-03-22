using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Enums;

namespace CoAntiCor.Core.Domain.Payment
{
    public class PaymentInitRequest : EntityBaseObject
    {
        public Guid? PaymentId { get; set; }
        public Payment? Payment { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "CDF"; // USD
        public PaymentProviderType Provider { get; set; }
        public string Description { get; set; } = "";
        public string CustomerPhone { get; set; } = "";
        public string CustomerEmail { get; set; } = "";

    }

}
