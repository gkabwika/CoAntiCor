using CoAntiCor.Core.Model;

using System.Threading.Tasks;

namespace CoAntiCor.Core.Interfaces
{
    public interface IProcessingPhaseEngine
    {
        Task ChangeStatusAsync(Guid complaintId, ComplaintStatus newStatus, Guid userId, string? comment = null);
    }
}
