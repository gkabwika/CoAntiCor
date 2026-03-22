
using CoAntiCor.Core.Domain;

namespace CoAntiCor.Core.Domain.Organization.PaymentMethods
{
    // Merchant = BankAccountModel, money gram. wester union etc
    public class CashOnDelivery : EntityBaseObject
    {
        public Guid? UserId { get; set; }   // Responsible Person userId
        public string PaymentMethodCode { get; set; } = "Cash";
        public string ReceiptNoBank { get; set; } = string.Empty;  //Numero Recepisse Bank
        //public BinaryData? ReceiptBank { get; set; }   // Recepisse Bank
        public decimal? FraisBancaire { get; set; } 
        public string Merchant { get; set; } = string.Empty;
        public string MerchantAddress { get; set; } = string.Empty;
        public string MerchantCity { get; set; } = string.Empty;
        public string MerchantPhone { get; set; } = string.Empty;
        public string MerchantEmail { get; set; } = string.Empty;
        public DateTime? CashPaymentDate { get; set; }
    }
}
