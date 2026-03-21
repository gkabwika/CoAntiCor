using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.DTO
{
    public class CreateComplaintResponse
    {
        public Guid ComplaintId { get; set; }
        public string ComplaintNumber { get; set; } = default!;
    }
}
