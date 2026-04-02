using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CoAntiCor.Core.Domain
{
    public class    ApplicationUser : IdentityUser
    {
        [PersonalData]
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [PersonalData]
        [MaxLength(100)]
        public string? MiddleName { get; set; }
        [PersonalData]
        [MaxLength(100)]
        public string? LastName { get; set; }
        public Guid? BrokerOfficeId { get; set; }
        public BrokerOffice? BrokerOffice { get; set; }

        public string PreferredLanguage { get; set; } = "fr-CD";
        public string PreferredTheme { get; set; } = "light";
        public string? ProvinceCode { get; set; }
    }
}
