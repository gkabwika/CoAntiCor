namespace CoAntiCor.Core.DTO
{
    public class UploadedFileDto
    {
        public string FileName { get; set; } = default!;
        public string ContentType { get; set; } = default!;
        public long Size { get; set; }
        public string TempStoragePath { get; set; } = default!;
    }
}
