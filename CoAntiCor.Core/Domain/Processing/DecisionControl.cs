using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Domain.Person;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoAntiCor.Core.Domain.Processing
{
    public class DecisionControl : EntityBaseObject
    {     
        public bool ProblemUnderControl { get; set; } = true; // probleme_controle
        [Display(Name = "Comments")]
        [Required]
        [StringLength(4000, MinimumLength = 1)]
        public string Comments { get; set; } = string.Empty;  // Desciption des problemes
        public DateTime? ValidationDate { get; set; } = DateTime.Now;
        public Guid? UserId { get; set; }
        public Guid ReasonRejectedId { get; set; } 
        [ForeignKey(nameof(ReasonRejectedId))]
        public ReasonRejected? ReasonRejecteds { get; set; } 
        public Guid NaturalPersonId { get; set; } 
        [ForeignKey(nameof(NaturalPersonId))]
        public NaturalPerson? NaturalPerson { get; set; } 
        public Guid SiteId { get; set; } 
        [ForeignKey(nameof(SiteId))]
        public Site? Sites { get; set; } 
       // public Guid ProductId { get; set; } 
       // [ForeignKey(nameof(ProductId))]
       //public Product? Products { get; set; } 
    }
}