
using System.ComponentModel.DataAnnotations.Schema;
namespace CoAntiCor.Core.Domain.Person
{
    public class NaturalPersonAddress : EntityBaseObject
    {      
        public Guid AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public Address.Address? Address { get; set; } = default!;
        public Guid NaturalPersonId { get; set; } // Custom FK property name
        [ForeignKey(nameof(NaturalPersonId))]
        public NaturalPerson? NaturalPerson { get; set; } = default!;// Reference navigation property
    }
}