namespace CoAntiCor.Data.Entities
{
    public class NavigationAudit
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string Path { get; set; } = default!;
        public DateTime TimestampUtc { get; set; }
    }

}
