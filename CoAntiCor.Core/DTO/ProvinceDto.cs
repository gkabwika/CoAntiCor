
using CoAntiCor.Core.Domain;

namespace CoAntiCor.Core.DTO
{
    public class ProvinceDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string NameFrench { get; set; }
        public string NameEnglish { get; set; }
    }
}
