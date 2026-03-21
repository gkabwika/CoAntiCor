using CoAntiCor.Core.DTO;

namespace CoAntiCor.Core.Interfaces
{
    /// <summary>
    /// Citizen UX Optimization Report (Based on Analytics)
    /// </summary>
    public interface IUxAnalyzer
    {
        Task<UxOptimizationReport> GenerateReportAsync();
    }
}
