
using CoAntiCor.Core.Domain;

namespace CoAntiCor.Core.Domain.Organization.PaymentMethods
{
    public class PayPal : EntityBaseObject
    {
        public Guid? UserId { get; set; }   // Responsible Person userId
        public string PaymentMethodCode { get; set; } = "PayPal";
        public string PayPalBuyerEmail { get; set; } = string.Empty; // Ex: gaby@mail.com - owner email or anyone else in that corporation
        public string PayPalBuyerPhone { get; set; } = string.Empty; // Ex: +24325647895 - owner email or anyone else in that corporation

    }
}