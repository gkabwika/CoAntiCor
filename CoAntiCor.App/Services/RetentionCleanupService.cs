using CoAntiCor.Core.Model;
using CoAntiCor.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CoAntiCor.Services
{
    public class RetentionCleanupService : BackgroundService
    {
        private readonly IServiceProvider _provider;
        private readonly RetentionSettings _settings;

        public RetentionCleanupService(IServiceProvider provider, IOptions<RetentionSettings> options)
        {
            _provider = provider;
            _settings = options.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _provider.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<CoAntiCorDbContext>();

                var cutoffComplaints = DateTime.UtcNow.AddYears(-_settings.ComplaintYearsAfterClosure);
                var oldClosedComplaints = await db.Complaints
                    .Where(c => c.Status == ComplaintStatus.Closed && c.UpdatedAt < cutoffComplaints)
                    .ToListAsync(stoppingToken);

                foreach (var c in oldClosedComplaints)
                {
                    // Anonymize instead of delete
                    c.ReporterName = null;
                    c.ReporterContactEmail = null;
                    c.ReporterContactPhone = null;
                    c.IsAnonymous = true;
                }

                await db.SaveChangesAsync(stoppingToken);

                // Sleep 24h
                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }
    }
}
