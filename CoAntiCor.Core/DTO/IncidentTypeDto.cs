
using CoAntiCor.Core.Domain;

namespace CoAntiCor.Core.DTO
{
    public class IncidentTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NameFrench { get; set; }
        public string Description { get; set; }
        public string DescriptionFrench { get; set; }
        public Guid IncidentCategoryId { get; set; }
        public IncidentCategory IncidentCategory { get; set; }
    }
}
