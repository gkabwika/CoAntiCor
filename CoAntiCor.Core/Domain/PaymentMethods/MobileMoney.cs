using CoAntiCor.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace CoAntiCor.Core.Domain.Organization.PaymentMethods
{
    public class MobileMoney : EntityBaseObject
    {
        public Guid? UserId { get; set; }   // Responsible Person userId
        public string PaymentMethodCode { get; set; } = "MobileMoney";
        [StringLength(50, MinimumLength = 1)]
        public string CarrierName { get; set; } = string.Empty; // Airtel, Orange, Vodacom etc
        public string MobileMoneyBuyerEmail { get; set; } = string.Empty; // Ex: gaby@mail.com - owner email or anyone else in that corporation
        [StringLength(15, MinimumLength = 1)]
        public string MobileMoneyBuyerPhone { get; set; } = string.Empty; // Ex: +24325647895 - owner email or anyone else in that corporation

    }
}