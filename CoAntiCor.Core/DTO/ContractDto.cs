using CoAntiCor.Core.Enums;

namespace CoAntiCor.Core.DTO
{
    public record GenerateContractRequest(Guid OfferId);
    public record ContractDto(
        Guid Id,
        string ContractNumber,
        string HtmlBody,
        ContractStatus Status);

}
