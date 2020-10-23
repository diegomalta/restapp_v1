using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestApp.Api.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        [Route("v1/products")]
        public async Task<IActionResult> Get()
        {
            var ret = new [] {
                new
                {
                    ProductId = 1,
                    ProductName = "Product One",
                    productCode = "code1"
                },
                new
                {
                    ProductId = 2,
                    ProductName = "Product Two",
                    productCode = "code2"
                }
            };
            return Ok(ret);
        }
    }
}
