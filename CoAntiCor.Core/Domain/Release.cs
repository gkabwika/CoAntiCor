
namespace CoAntiCor.Core.Domain
{
    public class Release: EntityBaseObject
    { 
        public string? ByUser { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Version { get; set; }
        public string? Note { get; set; }
    }
}
