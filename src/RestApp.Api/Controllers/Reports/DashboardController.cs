using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApp.Domain.Services;
using System;
using System.Threading.Tasks;

namespace RestApp.Api.Controllers.Reports
{
    [ApiController]
    [Route("api/reports/[controller]")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class DashboardController : ControllerBase
    {
        private readonly IReportsService _reportsService;

        public DashboardController(IReportsService reportsService)
        {
            this._reportsService = reportsService;
        }

        [HttpGet]        
        [Route("v1/GetDailyReport")]        
        public async Task<IActionResult> GetDailyReport()
        {
            try
            {
                return Ok(await _reportsService.GetDailyReport());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Trying to get daily report");
            }
        }
    }
}
