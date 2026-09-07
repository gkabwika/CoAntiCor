using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.DTO.Incident
{
    public class IncidentEvidenceUploadDto
    {
        public IFormFile File { get; set; } = default!;
    }
}
