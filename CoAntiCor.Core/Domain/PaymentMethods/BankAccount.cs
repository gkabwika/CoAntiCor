using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using CoAntiCor.Core.Domain;

namespace CoAntiCor.Core.Domain.Organization.PaymentMethods
{
    public class BankAccount : EntityBaseObject
    {
        public Guid? UserId { get; set; }   // Responsible Person userId
        public string PaymentMethodCode { get; set; } = "BankAccount";
        public string BankAccountType { get; set; } = string.Empty;  // Ex= checking, saving
        [StringLength(100, MinimumLength = 1)] 
        public string BankName { get; set; } = string.Empty;
        public string BankTransit { get; set; } = string.Empty;
        public string BankSwiftCode { get; set; } = string.Empty;
        public string BankAccountNumber { get; set; } = string.Empty;
        public string BankAddress { get; set; } = string.Empty;
        public string BankSubArea { get; set; } = string.Empty;
        public string BankCity { get; set; } = string.Empty;
        public string BankProvince { get; set; } = string.Empty;
        public string BankCountry { get; set; } = string.Empty;
        public string BankTel { get; set; } = string.Empty;
        public string BankEmail { get; set; } = string.Empty;
        public string BankFax { get; set; } = string.Empty;
    }
}
