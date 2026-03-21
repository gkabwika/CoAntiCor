using CoAntiCor.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Model
{
    public class AssignComplaintRequest
    {
        public Guid ComplaintId { get; set; }
        public Guid AssignedToUserId { get; set; }
        public string? Comment { get; set; }
    }

}
