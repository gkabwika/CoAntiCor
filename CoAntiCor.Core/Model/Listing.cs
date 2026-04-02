using CoAntiCor.Core.Interfaces;

namespace CoAntiCor.Core.Services
{
    public class Listing : ITenantScoped
    {
        public Guid Id { get; set; }
        public Guid BrokerOfficeId { get; set; }
        //....
  
    }
}
