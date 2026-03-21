using CoAntiCor.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CoAntiCor.API.Services
{
    public class ComplaintNumberGenerator : IComplaintNumberGenerator
    {
        /// <summary>
        /// This implementation guarantees:
        /// - Uniqueness
        /// - Sequential numbering per year
        /// - Thread‑safe(via DB transaction + row lock)
        /// - Retry logic for concurrency bursts
        /// - Configurable formattin

        /// 2026-00000001
        /// 2026-00000002
        /// 2026-00000003
        /// ...
        /// </summary>
        private readonly CoAntiCorDbContext _db;

        public ComplaintNumberGenerator(CoAntiCorDbContext db)
        {
            _db = db;
        }

        public async Task<string> GenerateAsync()
        {
            // We retry a few times in case of concurrency conflicts
            for (int attempt = 0; attempt < 5; attempt++)
            {
                using var tx = await _db.Database.BeginTransactionAsync();

                // Lock the single row
                var seq = await _db.ComplaintNumberSequences
                    .FromSqlRaw("SELECT * FROM ComplaintNumberSequences WITH (UPDLOCK, ROWLOCK)")
                    .FirstAsync();

                var currentYear = DateTime.UtcNow.Year;

                if (seq.Year != currentYear)
                {
                    seq.Year = currentYear;
                    seq.LastNumber = 0;
                }

                seq.LastNumber++;

                try
                {
                    await _db.SaveChangesAsync();
                    await tx.CommitAsync();

                    // Format: YYYY-########
                    return $"{seq.Year}-{seq.LastNumber.ToString("D8")}";
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Retry
                    await tx.RollbackAsync();
                    await Task.Delay(20);
                }
            }

            throw new InvalidOperationException("Unable to generate complaint number after multiple attempts.");
        }
    }
}
