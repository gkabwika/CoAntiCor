

namespace CoAntiCor.Core.Domain
{
    public class BrokerOffice : EntityBaseObject
    {
        public string Name { get; set; } = default!;
        public string City { get; set; } = default!;
        public string ProvinceCode { get; set; } = default!;
        public bool IsUrban { get; set; }

        public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}
