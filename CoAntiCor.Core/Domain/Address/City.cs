using System.ComponentModel.DataAnnotations;

namespace CoAntiCor.Core.Domain.Address
{
    public class City : EntityBaseObject    {   
        public string CountryCode { get; set; } = string.Empty;        
        public string ProvinceCode { get; set; } = string.Empty;        
        [StringLength(50, MinimumLength = 1)]
        public string CityName { get; set; } = string.Empty;
        public ICollection<Commune>? Communes { get; set; }
    }
}
