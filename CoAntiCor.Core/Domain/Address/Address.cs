
using System.ComponentModel.DataAnnotations;

namespace CoAntiCor.Core.Domain.Address
{    
    public class Address : EntityBaseObject
    {
      
        [StringLength(10, MinimumLength = 1)]
        public string StreetNumber { get; set; } = string.Empty;
        
        [StringLength(10, MinimumLength = 1)]
        public string SuiteNumber { get; set; } = string.Empty;

        [StringLength(30, MinimumLength = 1)]
        public string StreetType { get; set; } = string.Empty;
        [StringLength(50, MinimumLength = 1)]
        public string AddressStreet { get; set; } = string.Empty;
        
        [StringLength(50, MinimumLength = 1)]
        public string AddressSubArea { get; set; } = string.Empty;
        
        [StringLength(10, MinimumLength = 1)]
        public string PostalCode { get; set; } = string.Empty;
        [StringLength(30, MinimumLength = 1)]
        public string Quartier { get; set; } = string.Empty;

        [StringLength(30, MinimumLength = 1)]
        public string Commune { get; set; } = string.Empty;

        [StringLength(30, MinimumLength = 1)]
        public string City { get; set; } = string.Empty;
        
        [StringLength(50, MinimumLength = 1)]
        public string Province { get; set; } = string.Empty;
        
        [StringLength(3, MinimumLength = 1)]
        public string CountryCode { get; set; } = string.Empty;        
        public bool MainAddress { get; set; } = false;
    }
}