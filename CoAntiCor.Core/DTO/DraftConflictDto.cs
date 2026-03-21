namespace CoAntiCor.Core.DTO
{
    public class DraftConflictDto
    {
        public string ServerStateJson { get; set; } = default!;
        public int ServerVersion { get; set; }
    }
}
