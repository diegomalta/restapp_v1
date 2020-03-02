using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApp.Domain.Services;
using System.Threading.Tasks;

namespace restapp.Api.Controllers.Admin
{    
    [ApiController]
    [Route("api/admin/[controller]")]
    public class AnalyticsController : ControllerBase
    {
        private readonly IAnalyticsService _analyticsService;

        public AnalyticsController(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }
                
        [HttpGet]
        [Authorize]
        [Route("v1/GetDailyReport")]
        public async Task<IActionResult> GetDailyReport()
        {
            return StatusCode(StatusCodes.Status200OK);
        }
        
    }
}
