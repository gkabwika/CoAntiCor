
using CoAntiCor.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace CoAntiCor.Core.Domain.Organization.PaymentMethods
{    
    public class PaymentMethod : EntityBaseObject    
    {
        public string Code { get; set; } = string.Empty; // Ex = PayPal, Mpesa  
        public string? Name { get; set; }
        [StringLength(100, MinimumLength = 1)]
        public string? NameFrench { get; set; }
        [StringLength(100, MinimumLength = 1)]
        public string? NameEnglish { get; set; }

        [StringLength(4000, MinimumLength = 1)]
        public string? DescriptionFrench { get; set; }

        [StringLength(4000, MinimumLength = 1)]
        public string? DescriptionEnglish { get; set; }
    }
}