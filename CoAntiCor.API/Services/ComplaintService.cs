using CoAntiCor.Core.Interfaces;
using CoAntiCor.Core.DTO;
using CoAntiCor.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace CoAntiCor.API.Services
{
   
    public class ComplaintService : IComplaintService
    {
        private readonly CoAntiCorDbContext _db;

        public ComplaintService(CoAntiCorDbContext db) => _db = db;

        public async Task<List<ComplaintDetailDto>> SearchAsync(string term, int maxResults)
        {
            var normalized = Normalize(term);

            var cases = await _db.Complaints
                .Where(c => c.Id != null)
                .Take(500)
                .ToListAsync();

            return cases
                .Select(c => new ComplaintDetailDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    CreatedAt = c.CreatedAt,
                    IncidentCategory = c.IncidentCategory!.NameFrench,
                    IncidentType = c.IncidentType!.NameFrench,
                    IsAnonymous = c.IsAnonymous,
                    ReporterName = c.ReporterName,
                     City = c.City,
                    //Attachments = c.Attachments.ToList(),
                    Province = c.Province,
                    Description = c.Description.ToString(),
                    Status = c.Status,
                    ComplaintNumber = c.ComplaintNumber
                })
                .Where(r => r.CreatedAt > DateTime.Now.AddYears(-5))  // derniers 5 ans
                .OrderByDescending(r => r.CreatedAt)
                .Take(maxResults)
                .ToList();
        }

        public async Task<bool> IsNameAvailableAsync(string name)
        {
            var normalized = Normalize(name);
            return !await _db.Complaints
                .AnyAsync(c => c.Title == normalized);
        }

        private static string Normalize(string value) =>
            value.Trim().ToUpperInvariant();

        // Jaro–Winkler-ish or simple normalized Levenshtein
        private static double Similarity(string a, string b)
        {
            if (string.IsNullOrWhiteSpace(a) || string.IsNullOrWhiteSpace(b)) return 0;
            var distance = Levenshtein(a, b);
            var maxLen = Math.Max(a.Length, b.Length);
            return maxLen == 0 ? 1 : 1.0 - (double)distance / maxLen;
        }

        private static int Levenshtein(string s, string t)
        {
            var n = s.Length;
            var m = t.Length;
            var d = new int[n + 1, m + 1];

            for (var i = 0; i <= n; i++) d[i, 0] = i;
            for (var j = 0; j <= m; j++) d[0, j] = j;

            for (var i = 1; i <= n; i++)
                for (var j = 1; j <= m; j++)
                {
                    var cost = s[i - 1] == t[j - 1] ? 0 : 1;
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }

            return d[n, m];
        }
    }


}