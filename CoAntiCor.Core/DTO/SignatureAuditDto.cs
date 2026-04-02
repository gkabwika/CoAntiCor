
namespace CoAntiCor.Core.DTO
{
    public record SignatureAuditDto(
      string ActorUserId,
      string ActorRole,
      string Action,
      DateTime OccurredAtUtc,
      string? IpAddress,
      string? UserAgent);

}
