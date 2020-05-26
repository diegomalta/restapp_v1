using RestApp.Domain.Model.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApp.Domain.Queries.Reports
{
    public interface IReportsQuery
    {
        Task<IEnumerable<DailyReport>> GetDailyReport();
    }
}
