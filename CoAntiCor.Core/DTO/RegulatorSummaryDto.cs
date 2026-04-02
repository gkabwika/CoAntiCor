
namespace CoAntiCor.Core.DTO
{
    public record RegulatorSummaryDto(
     int TotalCadastreChecks,
     int CadastreValid,
     int CadastreInvalid,
     int LandSplitsTotal,
     int LandSplitsApproved,
     int LandSplitsRejected,
     decimal? AvgPricePerSqm);

}
