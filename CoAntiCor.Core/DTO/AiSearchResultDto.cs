
namespace CoAntiCor.Core.DTO
{
    public record AiSearchRequest(string Query);
    public record AiSearchFilter(
        string? City,
        string? Crop,
        decimal? MaxPriceUsd);
    public record AiSearchResultDto(
        Guid PropertyId,
        string Address,
        string City,
        string ProvinceCode,
        decimal? Price,
        string Currency,
        double DistanceKm);

}
