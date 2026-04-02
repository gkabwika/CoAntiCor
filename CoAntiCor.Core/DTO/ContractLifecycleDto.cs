using CoAntiCor.Core.Enums;

namespace CoAntiCor.Core.DTO
{
    public record ContractLifecycleDto(
      Guid OfferId,
      Guid? ContractId,
      string PropertyAddress,
      string BuyerName,
      string SellerName,
      decimal? OfferedPrice,
      string Currency,
      ContractStatus? ContractStatus,
      DateTime? BuyerSignedAtUtc,
      DateTime? SellerSignedAtUtc,
      //List<PaymentTimelineItemDto> Payments,
      //List<CadastreEventDto> CadastreEvents,
      //List<LandSplitSummaryDto> LandSplits,
        DateTime? Timestamp);
}
