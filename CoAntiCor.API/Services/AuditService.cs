using CoAntiCor.Core.Interfaces;
using CoAntiCor.Core.Model;
using CoAntiCor.Infrastructure.Context;
using System.Text.Json;

namespace CoAntiCor.API.Services
{
    public class AuditService : IAuditService
    {
        private readonly CoAntiCorDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuditService(CoAntiCorDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task LogAsync(AuditActionType actionType,
                                   string? entityType,
                                   string? entityId,
                                   string summary,
                                   object? details = null)
        {
            var http = _httpContextAccessor.HttpContext;
            var user = http?.User;

            Guid? userId = null;
            string? userName = null;

            if (user?.Identity?.IsAuthenticated == true)
            {
                var sub = user.FindFirst("sub")?.Value;
                if (Guid.TryParse(sub, out var parsed))
                    userId = parsed;

                userName = user.Identity?.Name ?? user.FindFirst("name")?.Value;
            }

            var log = new AuditLog
            {
                TimestampUtc = DateTime.UtcNow,
                UserId = userId,
                UserName = userName,
                ActionType = actionType,
                EntityType = entityType,
                EntityId = entityId,
                IpAddress = http?.Connection.RemoteIpAddress?.ToString(),
                UserAgent = http?.Request.Headers["User-Agent"].ToString(),
                Summary = summary,
                DetailsJson = details is null ? null : JsonSerializer.Serialize(details)
            };

            _db.AuditLogs.Add(log);
            await _db.SaveChangesAsync();
        }
    }
}
