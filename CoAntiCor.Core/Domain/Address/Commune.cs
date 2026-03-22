using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoAntiCor.Core.Domain.Address
{
    public class Commune : EntityBaseObject
    {        
         
        [StringLength(50, MinimumLength = 1)]
        public string CommuneName { get; set; } = string.Empty;
        public Guid CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public City? Cities { get; set; } // Reference navigation property
        public ICollection<Quartier>? Quartiers { get; set; }
    }
}
