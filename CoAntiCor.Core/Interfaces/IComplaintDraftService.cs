using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Model;

namespace CoAntiCor.Core.Interfaces
{
    public interface IComplaintDraftService
    {
        Task<Guid> SaveDraftAsync(ComplaintDraftState state, Guid? userId, bool isLinkclicked = false);
        Task<ComplaintDraftState?> LoadDraftAsync(Guid draftId, Guid? userId);
        Task<DraftSaveResult> SaveDraftV2Async(ComplaintDraftState state, Guid? userId = default, bool isLinkClicked = false);
    }
}
