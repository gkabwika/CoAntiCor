using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Domain.ServiceRequest
{
    public class IncidentEvidence :EntityBaseObject
    {
        public new Guid Id { get; set; }
        public Guid IncidentRequestId { get; set; }

        public string FileName { get; set; } = default!;
        public string ContentType { get; set; } = default!;
        public long SizeBytes { get; set; }

        public string StoragePath { get; set; } = default!; // e.g. blob path

        public DateTime UploadedAt { get; set; }
    }
}
