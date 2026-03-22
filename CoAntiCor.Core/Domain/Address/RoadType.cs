using System.ComponentModel.DataAnnotations;

namespace CoAntiCor.Core.Domain.Address
{ 
    public class RoadType : EntityBaseObject
    {  
        public string? LookupValue { get; set; } = string.Empty;
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;
    }
}
