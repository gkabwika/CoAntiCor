using CoAntiCor.Core.Model;

namespace CoAntiCor.API.V1.Controllers
{
    public interface IAuditPdfExporter
    {
        byte[] Export(List<AuditLog> logs);
    }
}