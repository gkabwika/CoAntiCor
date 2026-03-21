using System;
using System.Linq;

namespace CoAntiCor.Core.Domain
{
    public interface IEntityChangeData
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDT { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDT { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDT { get; set; }
        public bool MarkForDelete { get; set; }
    }
}
