using System.ComponentModel.DataAnnotations;

namespace CoAntiCor.Core.Domain.Person
{
    public class MaritalStatus : EntityBaseObject
    {
        public string Code { get; set; } = string.Empty;
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;
        [StringLength(50, MinimumLength = 1)]
        public string? NameFrench { get; set; } = string.Empty;
        [StringLength(50, MinimumLength = 1)]
        public string? NameEnglish { get; set; } = string.Empty;
        public ICollection<NaturalPerson>? NaturalPersons { get; set; }
    }
 }