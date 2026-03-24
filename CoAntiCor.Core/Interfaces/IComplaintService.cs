using CoAntiCor.Core.Domain;
using CoAntiCor.Core.DTO;
using CoAntiCor.Core.Model;

namespace CoAntiCor.Core.Interfaces
{
    public interface IComplaintService
    {
        //Task<Guid> SaveAsync(ComplaintDraftState state, Guid? userId, bool isLinkclicked = false);
        Task<List<ComplaintDetailDto>> SearchAsync(string term, int maxResults);
        Task<bool> IsNameAvailableAsync(string name);
    }
}
