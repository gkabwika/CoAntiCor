
namespace CoAntiCor.Core.Interfaces
{
    public interface ITenantContext
    {
        Guid? UserId { get; }
        Guid? BrokerOfficeId { get; }
        string? UserName { get; }
        string? ProvinceCode { get; }
        IReadOnlyList<string> Roles { get; }
        bool IsRegulator { get; }
    }

}
