using CoAntiCor.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace CoAntiCor.Core.Domain.Organization.PaymentMethods
{
    public class GiftCardPayInAdvance : EntityBaseObject
    {
        public Guid? UserId { get; set; }   // Responsible Person userId
        public string PaymentMethodCode { get; set; } = "GiftCard";
        [StringLength(50, MinimumLength = 1)]
        public string GiftCardName { get; set; } = string.Empty;
        public string GiftCardCode { get; set; } = string.Empty;
    }
}
