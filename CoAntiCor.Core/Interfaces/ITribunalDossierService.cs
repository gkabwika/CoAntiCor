using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Interfaces
{
    public interface ITribunalDossierService
    {
        Task<byte[]> GenerateDossierPdfAsync(Guid complaintId);
    }
}
