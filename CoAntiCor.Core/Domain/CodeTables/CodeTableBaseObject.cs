using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CoAntiCor.Core.Domain.CodeTables
{
    public class CodeTableBaseObject : BaseObject
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(256)]
        [Required]
        public string LookupValue { get; set; }

        [MaxLength(256)]
        [Required]
        public string? Name { get; set; }

        [MaxLength(256)]
        public string? NameFrench { get; set; }

        [MaxLength(256)]
        public string? NameEnglish { get; set; }
    }
}
