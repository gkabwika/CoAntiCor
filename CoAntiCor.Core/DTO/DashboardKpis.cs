using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.DTO
{
    public class DashboardKpis
    {
        public int TotalComplaints { get; set; }
        public int OpenComplaints { get; set; }
        public int UnderReview { get; set; }
        public int Escalated { get; set; }
        public int Approved { get; set; }
        public int Rejected { get; set; }

        public double AvgProcessingTimeDays { get; set; }
        public Dictionary<string, int> ComplaintsByProvince { get; set; } = new();
        public Dictionary<string, int> ComplaintsByCategory { get; set; } = new();
    }
}
