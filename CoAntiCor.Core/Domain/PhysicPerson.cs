using CoAntiCor.Core.Domain.Person;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoAntiCor.Core.Domain.Organization.OrganizationDetails
{
    public class PhysicPerson : EntityBaseObject
    {
        [Display(Name = "Is this victim organization?")]
        [Required]
        public bool? VictimOrganization { get; set; } = false;
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Organization Name")]
        public string? OrganizationName { get; set; } = string.Empty;
        [Display(Name = "Is this reporter organization?")]
        [Required]
        public bool? IsReporterOrganization { get; set; } = false;

        [StringLength(2000, MinimumLength = 1)]
        [Display(Name = "Organization Description")]
        public string? OrganizationDescription { get; set; } = string.Empty;
        [Display(Name = "Natural Person")]
        public Guid NaturalPersonId { get; set; }
        public NaturalPerson NaturalPerson { get; set; } = default!;

        [Display(Name = "Organization Address")]
        public List<OrganizationAddress> OrganizationAddress { get; set; } = new List<OrganizationAddress>();
        //public int ActivitySectorId { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;
        [Display(Name = "Web Site URL")]
        public string WebSiteURL { get; set; } = string.Empty;
        [Display(Name = "Sigle")]
        public string Sigle { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Industry Type")]
        public Guid IndustryTypeId { get; set; } // Custom FK property name
        [ForeignKey(nameof(IndustryTypeId))]
        [Display(Name = "Organization Category")]
        public Guid OrganizationCategoryId { get; set; } // Custom FK property name
        [ForeignKey(nameof(OrganizationCategoryId))]
        public OrganizationCategory? OrganizationCategory { get; set; } // Reference navigation property
        [Display(Name = "Enterprise Type")]
        public Guid EnterpriseTypeId { get; set; } // Custom FK property name
        [ForeignKey(nameof(EnterpriseTypeId))]
        [Display(Name = "IdNumP")]
        public string IdNumP { get; set; } = string.Empty; //????IdnumP
        public EnterpriseType? EnterpriseType { get; set; } // Reference navigation property

        public Guid ComplaintId { get; set; }
        public Complaint Complaint { get; set; } = default!;
    }
}
