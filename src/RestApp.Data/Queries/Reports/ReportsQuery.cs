using restapp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestApp.Domain.Queries.Reports;
using RestApp.Domain.Model.Queries;

namespace RestApp.Data.Queries.Reports
{
    public class ReportsQuery : IReportsQuery
    {
        private readonly RestAppDbContext _dbContext;

        public ReportsQuery(RestAppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<DailyReport>> GetDailyReport()
        {
            return await _dbContext.DailyReport.FromSqlRaw<DailyReport>(@"SELECT
                                                                             RD.dtFechaInicio [Date],
                                                                             SUM(CT.dTotal) [TotalAmount],
                                                                             COUNT(*) [TotalOrders],
                                                                             CAST(1 AS BIT) [IsActive]
                                                                         FROM
                                                                             TRNRegistroDia RD
                                                                             JOIN TRNCuentaTotal CT ON RD.iIDDia = CT.iIDDia
                                                                         WHERE
                                                                             bVentaActiva = 1
                                                                             OR RD.iIDDia = (
                                                                                 SELECT
                                                                                     MAX(TRD.iIDDia)
                                                                                 FROM
                                                                                     TRNRegistroDia TRD
                                                                             )
                                                                         GROUP BY
                                                                             RD.dtFechaInicio").AsNoTracking().ToListAsync();
        }
    }
}
