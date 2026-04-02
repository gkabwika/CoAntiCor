
namespace CoAntiCor.Core.DTO
{
    public record AuditSearchResultDto(
      Guid ContractId,
      string ContractNumber,
      string ActorUserId,
      string ActorRole,
      string Action,
      DateTime OccurredAtUtc,
      string? IpAddress);

}
