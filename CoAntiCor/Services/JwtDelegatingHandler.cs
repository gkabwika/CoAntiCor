using Humanizer;

namespace CoAntiCor.Services
{
    /// <summary>
    /// A delegating handler that: Attaches JWT to all API calls
    /// Supports silent token refresh when near expiry
    /// </summary>
    public class JwtDelegatingHandler : DelegatingHandler
    {
        private readonly JwtAuthenticationStateProvider _authProvider;
        private readonly IServiceProvider _services;

        public JwtDelegatingHandler(JwtAuthenticationStateProvider authProvider, IServiceProvider services)
        {
            _authProvider = authProvider;
            _services = services;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _authProvider.GetCurrentToken();

            if (!string.IsNullOrWhiteSpace(token))
            {
                if (_authProvider.IsTokenNearExpiry(TimeSpan.FromMinutes(5)))
                {
                    await TryRefreshTokenAsync(cancellationToken);
                    token = _authProvider.GetCurrentToken();
                }

                if (!string.IsNullOrWhiteSpace(token))
                {
                    request.Headers.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
            }

            return await base.SendAsync(request, cancellationToken);
        }

        private async Task TryRefreshTokenAsync(CancellationToken cancellationToken)
        {
            using var scope = _services.CreateScope();
            var http = scope.ServiceProvider.GetRequiredService<HttpClient>();

            // TODO: load refresh token from storage if you implement refresh tokens
            var refreshToken = "";
            if (string.IsNullOrWhiteSpace(refreshToken))
                return;

            var response = await http.PostAsJsonAsync("/api/auth/refresh", new { RefreshToken = refreshToken }, cancellationToken);
            if (!response.IsSuccessStatusCode)
                return;

            var newToken = await response.Content.ReadAsStringAsync(cancellationToken);
            await _authProvider.SetTokenAsync(newToken);
        }
    }


}
