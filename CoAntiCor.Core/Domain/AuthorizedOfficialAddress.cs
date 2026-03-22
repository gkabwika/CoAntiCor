using System.ComponentModel.DataAnnotations.Schema;
namespace CoAntiCor.Core.Domain
{
    public class AuthorizedOfficialAddress
    {      
        public Guid AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public Address.Address Address { get; set; } = default!;
        public Guid AuthorizedOfficialId { get; set; } // Custom FK property name
        [ForeignKey(nameof(AuthorizedOfficialId))]
        public AuthorizedOfficial AuthorizedOfficial { get; set; } = default!;// Reference navigation property
    }
}