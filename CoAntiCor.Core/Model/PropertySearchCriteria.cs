
namespace CoAntiCor.Core.Model
{
    public sealed class PropertySearchCriteria
    {
        public string? Query { get; init; }
        public string? PropertyType { get; init; }
        public bool? ForSale { get; init; }
        public bool? ForRent { get; init; }
        public decimal? MinPrice { get; init; }
        public decimal? MaxPrice { get; init; }
        public string? Currency { get; init; }
        public int Page { get; init; } = 1;
        public int PageSize { get; init; } = 20;
    }
}
