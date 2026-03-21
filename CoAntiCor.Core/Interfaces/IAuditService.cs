using CoAntiCor.Core.Model;

namespace CoAntiCor.Core.Interfaces
{
    public interface IAuditService
    {
        Task LogAsync(AuditActionType actionType,
                      string? entityType,
                      string? entityId,
                      string summary,
                      object? details = null);
    }
}
