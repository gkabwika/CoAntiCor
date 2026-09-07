using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Enums
{
    public enum IncidentStatus
    {
        Draft = 0,
        Submitted = 1,
        InReview = 2,
        PendingEvidence = 3,
        Accepted = 4,
        Escalated = 5,
        Closed = 6
    }
}
