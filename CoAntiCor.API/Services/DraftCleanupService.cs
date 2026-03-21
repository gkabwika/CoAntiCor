using CoAntiCor.Core.Model;
using CoAntiCor.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CoAntiCor.API.Services
{
    public class DraftCleanupService : BackgroundService
    {
        private readonly IServiceProvider _provider;
        private readonly DraftRetentionSettings _settings;

        public DraftCleanupService(IServiceProvider provider, IOptions<DraftRetentionSettings> options)
        {
            _provider = provider;
            _settings = options.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);

                using var scope = _provider.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<CoAntiCorDbContext>();

                var cutoff = DateTime.UtcNow.AddDays(-_settings.DaysToKeepDrafts);

                var oldDrafts = await db.ComplaintDrafts
                    .Where(d => d.LastUpdatedUtc < cutoff || d.IsCompleted)
                    .ToListAsync(stoppingToken);

                if (oldDrafts.Any())
                {
                    db.ComplaintDrafts.RemoveRange(oldDrafts);
                    await db.SaveChangesAsync(stoppingToken);
                }
            }
        }
    }
}
