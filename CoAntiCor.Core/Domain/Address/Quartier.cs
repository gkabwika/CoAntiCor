using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoAntiCor.Core.Domain.Address
{
    public class Quartier : EntityBaseObject
    {        
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;
        public Guid CommuneId { get; set; }
        [ForeignKey(nameof(CommuneId))]
        public Commune? Communes { get; set; } // Reference navigation property
    }
}
