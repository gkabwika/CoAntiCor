using Microsoft.AspNetCore.Authorization;

namespace CoAntiCor.API.Model
{
   

    public class TenantRequiredAttribute : AuthorizeAttribute
    {
        public TenantRequiredAttribute()
        {
            Policy = "TenantRequired";
        }
    }
}
