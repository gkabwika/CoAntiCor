using System.ComponentModel.DataAnnotations;
namespace CoAntiCor.Core.Domain.Payment
{
    public class PayPalPaymentModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string? PayerId { get; set; }
    }
  
}
