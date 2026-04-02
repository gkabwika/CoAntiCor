
namespace CoAntiCor.Core.Interfaces
{
    /// <summary>
    /// - Every query to automatically filter by BrokerOfficeId
    ///- Without writing.Where(x => x.BrokerOfficeId == tenant.BrokerOfficeId) everywhere
    ///- Without developers accidentally leaking data
    /// </summary>
    public interface ITenantScoped
    {
        Guid BrokerOfficeId { get; set; }
    }
}
