
namespace CoAntiCor.Core.DTO
{
    public record AuditSearchRequest(
     string? UserId,
     string? ContractNumber,
     DateTime? FromUtc,
     DateTime? ToUtc,
     string? Action);

}
