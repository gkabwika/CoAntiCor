
using CoAntiCor.Core.Domain;

namespace CoAntiCor.Core.Interfaces
{
    public interface IContractPdfService
    {
        byte[] Generate(Contract contract);
    }

}
