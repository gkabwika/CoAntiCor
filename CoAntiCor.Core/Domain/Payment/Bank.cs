using CoAntiCor.Core.Domain;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CoAntiCor.Core.Domain.Finance
{
    public class Bank: EntityBaseObject
    {
        public string Code { get; set; } = string.Empty;
        [StringLength(100, MinimumLength = 1)]
        public string BankName { get; set; } = string.Empty;
        [StringLength(20, MinimumLength = 1)]
        public string BankAccount { get; set; } = string.Empty;
        [StringLength(20, MinimumLength = 1)]
        public string BankTransit { get; set; } = string.Empty;
        [StringLength(20)]
        public string BankSWIFT { get; set; } = string.Empty;
        [StringLength(100)]
        public string BankAddress { get; set; } = string.Empty;
    }
}


