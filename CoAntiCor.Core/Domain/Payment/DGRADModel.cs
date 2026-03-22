using CoAntiCor.Core.Domain;
//using System.Memory.Data;

namespace CoAntiCor.Core.Domain.Finance
{
    //    
    public class DGRADModel : EntityBaseObject
    {     
        public Guid? UserId { get; set; } 
        public int NaturalPersonId { get; set; }
        public int InvoiceId { get; set; }
        public int SocialReasonId { get; set; }
        public string IdNumP { get; set; } = string.Empty; //????
        public int Requerant { get; set; }
        public string CurrencyCode { get; set; } = string.Empty;
        public decimal AmountRCCM { get; set; }  //Frais
        public decimal AmountIdNat { get; set; }  //Frais
        public string NumeroNote { get; set; } = string.Empty;
        public string NumeroOrd { get; set; } = string.Empty;
       // 
        //public BinaryData? PerceptionNote { get; set; }  // note de perception

    }
}


