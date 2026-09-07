using CoAntiCor.Core.Domain.ServiceRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoAntiCor.Core.Model
{
    public static class ServiceRequestQueryExtensions
    {
        public static IQueryable<ServiceRequest> ApplyPeriodFilter(
            this IQueryable<ServiceRequest> query,
            string? period)
        {
            if (string.IsNullOrWhiteSpace(period))
                return query;

            var now = DateTime.UtcNow;

            return period switch
            {
                "Last30Days" => query.Where(x => x.CreatedAt >= now.AddDays(-30)),
                "LastQuarter" => query.Where(x => x.CreatedAt >= now.AddMonths(-3)),
                "YearToDate" => query.Where(x => x.CreatedAt >= new DateTime(now.Year, 1, 1)),
                _ => query
            };
        }
    }

}
