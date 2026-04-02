using CoAntiCor.Core.Interfaces;
using CoAntiCor.Core.Model;
using CoAntiCor.Infrastructure.Context;

namespace CoAntiCor.API.Services
{  
    public interface ICaseFilePdfService
    {
        Task<CaseFileBundle> GenerateAsync(Guid offerId, CoAntiCorDbContext db,
            IContractPdfService contractPdf);
    }

}
