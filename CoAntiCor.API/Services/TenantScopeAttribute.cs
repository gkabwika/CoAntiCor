using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using CoAntiCor.Core.Interfaces;

namespace CoAntiCor.API.Services
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class TenantScopeAttribute : Attribute, IAsyncActionFilter
    {
        public bool RequireTenant { get; }

        public TenantScopeAttribute(bool requireTenant = false)
        {
            RequireTenant = requireTenant;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var tenant = context.HttpContext.RequestServices.GetRequiredService<ITenantContext>();

            // Optionally enforce tenant presence
            if (RequireTenant && tenant.BrokerOfficeId == null)
            {
                context.Result = new ForbidResult();
                return;
            }

            // Expose tenant to action via HttpContext.Items if needed
            context.HttpContext.Items["Tenant"] = tenant;

            await next();
        }
    }
}
