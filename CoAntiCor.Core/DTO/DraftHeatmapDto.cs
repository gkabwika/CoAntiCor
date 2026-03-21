
namespace CoAntiCor.Core.DTO
{
    public class DraftHeatmapDto
    {
        public Dictionary<string, int> DraftsByProvince { get; set; } = new();
        public Dictionary<int, int> DraftsByHour { get; set; } = new();
    }
}
