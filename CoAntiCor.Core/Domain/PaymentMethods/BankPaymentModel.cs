using System.ComponentModel.DataAnnotations;
namespace CoAntiCor.Core.Domain.Payment
{
    public class BankPaymentModel
    {
        [Required]
        public string AccountHolder { get; set; } = string.Empty;

        [Required]
        public string BankName { get; set; } = string.Empty;

        [Required]
        [StringLength(34, MinimumLength = 6)]
        public string AccountNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(11, MinimumLength = 3)]
        public string RoutingNumber { get; set; } = string.Empty;
    }
}
