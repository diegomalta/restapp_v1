using RestApp.Domain.Model.Queries;
using RestApp.Domain.Queries.Reports;
using RestApp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApp.Api.Services
{
    public class ReportsService : IReportsService
    {
        private readonly IReportsQuery _reportsQuery;

        public ReportsService(IReportsQuery reportsQuery)
        {
            this._reportsQuery = reportsQuery;
        }

        public async Task<IEnumerable<DailyReport>> GetDailyReport()
        {
            return await _reportsQuery.GetDailyReport();
        }
    }
}
