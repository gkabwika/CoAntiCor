
namespace CoAntiCor.Core.DTO
{
    public record RegulatorExportRow(
      string EventType,
      string TitleNumber,
      string Province,
      bool? CadastreValid,
      string? Message,
      DateTime Timestamp);

}
