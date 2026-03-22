using System.ComponentModel.DataAnnotations;

namespace CoAntiCor.Core.Domain.Person
{
    public class OfficialDiscussion : EntityBaseObject
    {
        public string Code { get; set; } = string.Empty;
        public string? Discussion { get; set; } = string.Empty;
        public Complaint? Complaint { get; set; }
    }
}