using CoAntiCor.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace CoAntiCor.Core.Domain.Organization.PaymentInfo
{    
    public class PaymentStatus : EntityBaseObject
    {
        public string Code { get; set; } = string.Empty;         
        [StringLength(50, MinimumLength = 1)]
        public string StatusName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}