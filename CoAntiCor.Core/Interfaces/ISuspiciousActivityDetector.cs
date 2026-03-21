using CoAntiCor.Core.Model;

namespace CoAntiCor.Core.Interfaces
{
    public interface ISuspiciousActivityDetector
    {
        Task<SuspiciousActivityResult> AnalyzeDraftAsync(Guid draftId);
    }
}
