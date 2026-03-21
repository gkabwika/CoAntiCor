using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.DTO
{
    public class SimilarIncidentDto
    {
        public Guid ComplaintId { get; set; }
        public string ComplaintNumber { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string ShortDescription { get; set; } = default!;
        public double SimilarityScore { get; set; }
    }
}
