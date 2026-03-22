using System.ComponentModel.DataAnnotations;
namespace CoAntiCor.Core.Domain.Payment
{
    public class MobileMoneyPaymentModel
    {
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Provider { get; set; } = string.Empty;

        [Required]
        public string Country { get; set; } = string.Empty;
    }
}
