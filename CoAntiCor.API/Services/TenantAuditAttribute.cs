namespace CoAntiCor.API.Services
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using CoAntiCor.Core.Domain;
    using CoAntiCor.Core.Interfaces;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class TenantAuditAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string? _entityName;

        public TenantAuditAttribute(string? entityName = null)
        {
            _entityName = entityName;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var executed = await next();

            var http = context.HttpContext;
            var tenant = http.RequestServices.GetRequiredService<ITenantContext>();
            var audit = http.RequestServices.GetRequiredService<ITenantAuditService>();

            var descriptor = context.ActionDescriptor as Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor;

            var entry = new TenantAuditEntry
            {
                UserId = tenant.UserId,
                BrokerOfficeId = tenant.BrokerOfficeId,
                ProvinceCode = tenant.ProvinceCode,
                IpAddress = http.Connection.RemoteIpAddress?.ToString(),
                ControllerName = descriptor?.ControllerName,
                ActionName = descriptor?.ActionName,
                EntityName = _entityName,
                // You can enrich EntityId/DetailsJson from route values or result if needed
            };

            await audit.LogAsync(entry);
        }
    }
}
