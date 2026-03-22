using System.ComponentModel.DataAnnotations;
namespace CoAntiCor.Core.Domain.Payment
{   
    public class CardPaymentModel
    {
        [Required]
        [StringLength(100)]
        public string CardholderName { get; set; } = string.Empty;

        [Required]
        [CreditCard]
        [StringLength(19, MinimumLength = 12)]
        public string CardNumber { get; set; } = string.Empty;

        [Range(1, 12)]
        public int ExpiryMonth { get; set; }

        [Range(2024, 2100)]
        public int ExpiryYear { get; set; }

        [Required]
        [StringLength(4, MinimumLength = 3)]
        public string Cvv { get; set; } = string.Empty;
    }
    

}
