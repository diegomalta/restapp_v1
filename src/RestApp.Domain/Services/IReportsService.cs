using RestApp.Domain.Model.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApp.Domain.Services
{
    public interface IReportsService
    {
        Task<IEnumerable<DailyReport>> GetDailyReport();
    }
}
