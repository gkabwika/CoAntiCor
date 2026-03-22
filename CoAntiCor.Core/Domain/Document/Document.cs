using System.ComponentModel.DataAnnotations;

using CoAntiCor.Core.Domain.Processing;

namespace CoAntiCor.Core.Domain.Document
{
    public class Document
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Guid ServiceRequestId { get; set; }
        public string DocumentType { get; set; } = default!;
        public string FileName { get; set; } = default!;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }

}
