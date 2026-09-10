using CoAntiCor.Core.Domain.ServiceRequest;

namespace CoAntiCor.API.Services.Interface
{
    public interface IIncidentSecurityRiskService
    {
        IncidentSecurityDetail ComputeRisk(IncidentSecurityDetail detail);
    }
}
