
namespace CoAntiCor.Core.Domain.Email
{

    public class EmailQueueItem
    {
        public long Id { get; set; }
        public string To { get; set; } = default!;
        public string? Cc { get; set; }
        public string? Bcc { get; set; }
        public string Subject { get; set; } = default!;
        public string Body { get; set; } = default!;
        public bool IsHtml { get; set; } = true;
        public string Status { get; set; } = "Pending";
        public int Attempts { get; set; }
        public DateTime NextAttemptUtc { get; set; }
        public string? RelatedEntity { get; set; }
        public Guid? RelatedId { get; set; }
        public DateTime CreatedUtc { get; set; }
    }

}
