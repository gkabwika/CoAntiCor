using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CoAntiCor.Core.Domain
{
    public class EntityBaseObject : BaseObject
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
