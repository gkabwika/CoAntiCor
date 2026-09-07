using CoAntiCor.Core.Domain.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Domain.ServiceRequest
{
    public class IncidentRequestNaturalPerson
    {
        public Guid IncidentRequestId { get; set; }
        public IncidentRequest IncidentRequest { get; set; } = default!;

        public Guid NaturalPersonId { get; set; }
        public NaturalPerson NaturalPerson { get; set; } = default!;
    }
}
