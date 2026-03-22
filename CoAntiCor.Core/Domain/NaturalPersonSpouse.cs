using System.ComponentModel.DataAnnotations.Schema;

namespace CoAntiCor.Core.Domain.Person
{ 
    //Conjoints(es)
    public class NaturalPersonSpouse : EntityBaseObject
    {   
        public Guid NaturalPersonId { get; set; } // parentID = spouse. Ex. Mari
        [ForeignKey(nameof(NaturalPersonId))]
        public NaturalPerson? NaturalPerson { get; set; } // Reference navigation property      
        public bool? Divorced { get; set; } = false;
        public DateTime? DivorceDate { get; set; } 
    }
}
