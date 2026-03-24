using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.DTO
{
    public class CreateComplaintRequest
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;

        public Guid IncidentTypeId { get; set; }
        public Guid IncidentCategoryId { get; set; }

        public bool IsAnonymous { get; set; }

        public string? ReporterName { get; set; }
        public string? ReporterEmail { get; set; }
        public string? ReporterPhone { get; set; }

        public string? Province { get; set; }
        public string? City { get; set; }

        public Guid? GovernmentOfficeId { get; set; }

        public List<CreateComplaintAttachmentRequest> Attachments { get; set; } = new();
    }
}
