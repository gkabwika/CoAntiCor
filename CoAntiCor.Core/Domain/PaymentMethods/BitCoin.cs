
using CoAntiCor.Core.Domain;

namespace CoAntiCor.Core.Domain.Organization.PaymentMethods
{    
    public class BitCoin : EntityBaseObject
    {
        // Accept payments in Bitcoin - Cryptocurrency        
        public Guid? UserId { get; set; }   // Responsible Person userId
        public string PaymentMethodCode { get; set; } = "BitCoin";
        public string BitCoinURI { get; set; } = string.Empty;
        public string BitCoinUnit{ get; set; } = string.Empty;
        public string BitCoinQRCode { get; set; } = string.Empty;
        public string WalletType { get; set; } = string.Empty;  
        public string MerchantName { get; set; } = string.Empty;
        public string MerchantTransit { get; set; } = string.Empty;
        public string MerchantAccountNumber { get; set; } = string.Empty;
        public string MerchantAddress { get; set; } = string.Empty;
        public string MerchantSubArea { get; set; } = string.Empty;
        public string MerchantCity { get; set; } = string.Empty;
        public string MerchantProvince { get; set; } = string.Empty;
        public string MerchantCountry { get; set; } = string.Empty;
        public string MerchantTel { get; set; } = string.Empty;
        public string MerchantEmail { get; set; } = string.Empty;
        public string MerchantFax { get; set; } = string.Empty;
    }
}
