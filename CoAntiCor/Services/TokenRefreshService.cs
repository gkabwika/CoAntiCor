namespace CoAntiCor.Services
{
    public class TokenRefreshService : IHostedService, IDisposable
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private Timer? _timer;

        public TokenRefreshService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(5));
            return Task.CompletedTask;
        }

        private async void DoWork(object? state)
        {
            using var scope = _scopeFactory.CreateScope();
            var authProvider = scope.ServiceProvider.GetRequiredService<JwtAuthenticationStateProvider>();
            var http = scope.ServiceProvider.GetRequiredService<HttpClient>();

            // You can extend JwtAuthenticationStateProvider to expose current token/expiry if needed
            // If token is near expiry → call /api/auth/refresh → AuthProvider.SetTokenAsync(newToken)
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose() => _timer?.Dispose();
    }

}
