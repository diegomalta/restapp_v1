using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RestApp.Domain.Model;
using RestApp.Domain.Services;
using System.Threading.Tasks;

namespace RestApp.Api.Controllers.Security
{
    [ApiController]
    [Route("api/security/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        [Route("v1/GenerateToken")]
        public async Task<IActionResult> GenerateToken([FromBody] TokenRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.GenerateToken(request);
                if (result.IsSuccess)
                {
                    return StatusCode(StatusCodes.Status200OK, result);
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest, "Invalid Request");
        }
    }
}
