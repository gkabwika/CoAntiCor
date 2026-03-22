using System.ComponentModel.DataAnnotations;

namespace CoAntiCor.Core.Domain.Address
{
    public class Territory : EntityBaseObject
    {
        public string? Code { get; set; }
        public string ProvinceCode { get; set; } = string.Empty; 
        public string CountryCode { get; set; } = string.Empty;
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;
    }
}
