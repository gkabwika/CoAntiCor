using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Domain
{
    public class GovernmentOffice : EntityBaseObject
    {
        public string Name { get; set; } = default!;
        public string Province { get; set; } = default!;
        public string City { get; set; } = default!;
        public string AddressLine { get; set; } = default!;
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();
    }
}
