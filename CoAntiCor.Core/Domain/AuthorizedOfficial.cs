
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoAntiCor.Core.Domain
{
    public class AuthorizedOfficial : EntityBaseObject
    {
        public Guid? UserId { get; set; }  // Ex = userId of Person who created this account
        public string PrivateCorporationName { get; set; } = string.Empty;  // Private. corporate Lawyer office
        public string Title { get; set; } = string.Empty; // Ex: Honnorable
        public string FirstName { get; set; } = string.Empty; // Ex: Gabriel
        public string LastName { get; set; } = string.Empty; // Ex: Baloji
        public string MiddleName { get; set; } = string.Empty; // Ex: Kabwika
        public string Email { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string LanguagePreference { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty; // Ex= Canadian
        public string Country { get; set; } = string.Empty; // Ex = R.D. Congo
        public int? EffectiveYear { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Display(Name = "Authorized Official Address")]
        [NotMapped] 
        public ICollection<AuthorizedOfficialAddress> AuthorizedOfficialAddress { get; set; } = new List<AuthorizedOfficialAddress>();
    }
}
