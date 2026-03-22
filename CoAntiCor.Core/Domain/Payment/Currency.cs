using CoAntiCor.Core.Domain;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CoAntiCor.Core.Domain.Finance
{
    //Currency
    
    public class Currency : EntityBaseObject
    {        
        public string Code { get; set; } = string.Empty;
        [StringLength(50, MinimumLength = 1)]
        public string CurrencyName { get; set; } = string.Empty;
        public string CurrencySymbol { get; set; } = string.Empty;

    }
}


