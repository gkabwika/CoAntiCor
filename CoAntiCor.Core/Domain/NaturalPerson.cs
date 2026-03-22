using CoAntiCor.Core.Domain.Address;
using CoAntiCor.Core.Domain.Organization.OrganizationDetails;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoAntiCor.Core.Domain.Person
{
    //personne naturelle(s)
    public class NaturalPerson : EntityBaseObject
    {
        [Display(Name = "Is this victim person?")]
        [Required]
        public bool? IsVictimPerson { get; set; } = false;
        [Display(Name = "Is this reporter person?")]
        [Required]
        public bool? IsReporterPerson { get; set; } = false;

        [Display(Name = "Company")]
       // public Guid PhysicPersonId { get; set; } // Company / societe
        //[ForeignKey(nameof(PhysicPersonId))]
        //public PhysicPerson? PhysicPerson { get; set; } // Optional reference navigation to principal
        public ICollection<PhysicPerson>? PhysicPersons { get; set; } // Ex: //PhysicPerson

        [Display(Name = "First Name")]
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string? FirstName { get; set; } = string.Empty;  // Prenom
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; } = string.Empty;  // Post Nom
        [Display(Name = "Last Name")]
        [StringLength(100, MinimumLength = 1)]
        [Required]
        public string? LastName { get; set; } = string.Empty;  // Nom
        [Display(Name = "Nationality Country")]
        public List<Country>? NationalityCountry { get; set; } = new List<Country>();// Ex: // Pays de nationalité. Canada, RDC, etc
        [Required]
        [Display(Name = "Birth Location")]
        public string? BirthLocation { get; set; } = string.Empty;  // Lieu de naissance
        [Required]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public Guid GenderId { get; set; } // Custom FK property name
        [ForeignKey(nameof(GenderId))]
        public Gender? Gender { get; set; } // Reference navigation property
        [Required]
        [Display(Name = "Civility")]
        public Guid CivilityId { get; set; } // Custom FK property name
        [ForeignKey(nameof(CivilityId))]
        public Civility? Civility { get; set; } // Reference navigation property
        [Required]
        [Display(Name = "Marital Status")]
        public Guid MaritalStatusId { get; set; } // // etat civil
        [ForeignKey(nameof(MaritalStatusId))]
        public MaritalStatus? MaritalStatus { get; set; } // Reference navigation property   
        [Display(Name = "Spouses ")]
        public ICollection<NaturalPersonSpouse>? NaturalPersonSpouses { get; set; } // Ex: //conjointes
        [Display(Name = "Phone Personal")]
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string? PhonePersonal { get; set; } = string.Empty;  // Prenom
        [Display(Name = "Business Phone")]
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string? PhoneBusiness { get; set; } = string.Empty;  // Prenom
        [Display(Name = "Email Address")]
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string? EmailAddress { get; set; } = string.Empty;  // Prenom

        [Required]
        [Display(Name = "Addresses")]
        public ICollection<Address.Address>? CurrentAddress { get; set; } //Ex: Address 1, Address 2 etc

        public Guid ComplaintId { get; set; }
        public Complaint Complaint { get; set; } = default!;

    }

  
}
