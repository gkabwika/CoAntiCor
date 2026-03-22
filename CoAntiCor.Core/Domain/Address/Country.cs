using System.ComponentModel.DataAnnotations;

namespace CoAntiCor.Core.Domain.Address
{ 
    public class Country : EntityBaseObject
    {  
        [StringLength(3, MinimumLength = 2)]
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        [StringLength(50, MinimumLength = 1)]
        public string NameFrench { get; set; } = string.Empty;
        [StringLength(50, MinimumLength = 1)]
        public string NameEnglish { get; set; } = string.Empty;
    }
}
