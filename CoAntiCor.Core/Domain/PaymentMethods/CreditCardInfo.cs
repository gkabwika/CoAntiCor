using CoAntiCor.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace CoAntiCor.Core.Domain.Organization.PaymentMethods
{
    public class CreditCardInfoModel : EntityBaseObject
    {
        public Guid? UserId { get; set; }   // Responsible Person userId
        public string PaymentMethodCode { get; set; } = "CreditCard";
        public string CreditCardType { get; set; } = string.Empty;  // Ex= Visa, Master, Amex
        [StringLength(50, MinimumLength = 1)]
        public string CreditCardName { get; set; } = string.Empty;
        [StringLength(24, MinimumLength = 1)]
        public string CreditCardNumber { get; set; } = string.Empty;
        public int? CreditCardExpiryMonth { get; set; }
        public int? CreditCardExpiryYear { get; set; }
        public int? CreditCardExpiryBackCode { get; set; }
    }
}