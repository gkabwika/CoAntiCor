
namespace CoAntiCor.Core.Domain.Organization.OrganizationDetails
{    
    public class OrganizationAddress : EntityBaseObject
    {
        public int? OrganizationId { get; set; }
        public int? AddressId { get; set; }
        public bool? HeadQuarter { get; set; } = false;
        public bool? OperationLocation { get; set; } = false;
        public bool? OwnerPrivateResidentialLocation { get; set; } = false;
        public PhysicPerson? PhysicPerson { get; set; } // Optional reference navigation to principal

    }
}