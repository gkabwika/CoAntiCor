using System.Runtime.Intrinsics.X86;

namespace CoAntiCor.Core.Domain.Reporting
{
    /// <summary>
    /// Role‑based access control (RBAC) model for reporting
    ///Roles:
    ///ReportingViewer – can view tenant‑scoped reports
    ///ReportingAdmin – can view all tenants, export, and see detailed audit
    ///Regulator – cross‑tenant, read‑only, full history
    /// </summary>
    public static class ReportingRoles
    {
        public const string ReportingViewer = "ReportingViewer";
        public const string ReportingAdmin = "ReportingAdmin";
        public const string Regulator = "Regulator";
    }

}
