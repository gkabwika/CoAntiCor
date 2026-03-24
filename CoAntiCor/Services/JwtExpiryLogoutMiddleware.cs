using System.Security.Claims;

namespace CoAntiCor.Services
{
    public class JwtExpiryLogoutMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtExpiryLogoutMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var user = context.User;
            if (user?.Identity?.IsAuthenticated == true)
            {
                var exp = user.FindFirst("exp")?.Value;
                if (long.TryParse(exp, out var seconds))
                {
                    var expiry = DateTimeOffset.FromUnixTimeSeconds(seconds);
                    if (expiry <= DateTimeOffset.UtcNow)
                    {
                        // token expired → clear principal
                        context.User = new ClaimsPrincipal(new ClaimsIdentity());
                    }
                }
            }

            await _next(context);
        }
    }

}
