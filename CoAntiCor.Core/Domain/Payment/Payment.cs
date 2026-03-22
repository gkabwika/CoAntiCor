using CoAntiCor.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoAntiCor.Core.Domain.Payment
{
    public class Payment  //: AggregateRoot
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Guid CompanyRequestId { get; set; }
        public Guid ServiceRequestId { get; set; }
       // public CompanyRequest CompanyRequest { get; set; } = default!;
        public decimal Amount { get; set; }        
        public string Currency { get; set; } = "CDF"; //USD
        public string? TransactionReference { get; set; }
        [Required]
        [Display(Name = "Payment Status")]
        public Guid PaymentStatusId { get; set; }
        [ForeignKey(nameof(PaymentStatusId))]
        public PaymentStatus PaymentStatus { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Succeeded, Failed
        public string Method { get; set; } = default!;
        public string TransactionID { get; set; } = string.Empty; // Ex = 34327yhujndreygdiusfsdf324
        public decimal PaymentAmount { get; set; } = 0; //   Ex = 100.00
        public DateTime? PaymentDate { get; set; }
        public string PaymentReference { get; set; } = string.Empty;
        public string? ProviderPaymentId { get; set; }
        public string? ProviderReference { get; set; }
        public int RetryCount { get; set; }

        public string? Provider { get; set; } // CreditCard, PayPal, MPESA, AirtelMoney, OrangeMoney, Bank, DGRAD
        public DateTime CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset CompletedAt { get; set; }
        public DateTime? PaidAt { get; set; } //PaymentDate
        public DateTime ExpiresAt { get; set; } // 24h for pay-later

        //Payment extends AggregateRoot and raises event:
        public void MarkAsPaid() {
            Status =PaymentStatus.Paid.ToString() ; 
            PaidAt = DateTime.UtcNow; 
           // AddEvent(new PaymentReceivedEvent(Id, ServiceRequestId)); 
        }
    }
}
