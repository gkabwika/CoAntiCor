using CoAntiCor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Domain
{
    public class ComplaintHistory : EntityBaseObject
    {

        public Guid ComplaintId { get; set; }
        public Complaint Complaint { get; set; } = default!;

        public ComplaintStatus OldStatus { get; set; }
        public ComplaintStatus NewStatus { get; set; }

        public Guid ChangedByUserId { get; set; }
        public User ChangedByUser { get; set; } = default!;

        public DateTime ChangedAt { get; set; }

        public string? Comment { get; set; }
    }
}
