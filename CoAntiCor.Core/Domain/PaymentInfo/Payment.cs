
using CoAntiCor.Core.Domain.Person;
using CoAntiCor.Core.Enums;
using CoAntiCor.Core.Domain.Organization.PaymentMethods;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoAntiCor.Core.Domain.Organization.PaymentInfo
{
    public class PaymentProcess
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Guid ServiceRequestId { get; set; }
        [Required]
        [Display(Name = "Payment Status")]
       
        public CoAntiCor.Core.Enums.PaymentStatus PaymentStatus { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Succeeded, Failed

        [Required]
        [Display(Name = "User Payment Method")]
        public Guid PaymentMethodId { get; set; } //top active payment method of the user
        [ForeignKey(nameof(PaymentMethodId))]
        public PaymentMethod? UserPaymentMethod { get; set; } // Reference navigation property
        public string Method { get; set; } = default!;

        [Required]
        [Display(Name = "Natural Person")]
        public Guid NaturalPersonId { get; set; } // Natural Person Id
        [ForeignKey(nameof(NaturalPersonId))]
        public NaturalPerson? NaturalPerson { get; set; } // Reference navigation property

        public string TransactionID { get; set; } = string.Empty; // Ex = 34327yhujndreygdiusfsdf324
        public decimal PaymentAmount { get; set; } = 0; //   Ex = 100.00
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "CDF"; //USD, CDF, EUR, etc
        public DateTime? PaymentDate { get; set; }
        public string PaymentReference { get; set; } = string.Empty;
        public string? ProviderPaymentId { get; set; }
        public string? ProviderReference { get; set; }
        public int RetryCount { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset CompletedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDT { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDT { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDT { get; set; }
        public bool MarkForDelete { get; set; } = false;
        public DateTime? PaidAt { get; set; } //PaymentDate
        public DateTime ExpiresAt { get; set; } // 24h for pay-later

        //Payment extends AggregateRoot and raises event:
        public void MarkAsPaid()
        {
            Status = CoAntiCor.Core.Enums.PaymentStatus.Paid.ToString();
            PaidAt = DateTime.UtcNow;
           // AddEvent(new PaymentReceivedEvent(Id, ServiceRequestId));
        }
    }
}
