
using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Domain.Address;
using CoAntiCor.Core.Domain.Email;
using System.Numerics;
using System.Xml.Linq;

namespace CoAntiCor.Core.DTO
{
    public class GovernmentOfficeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
