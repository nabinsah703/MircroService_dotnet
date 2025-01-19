using Microsoft.AspNetCore.Mvc;
using Product.Models;

namespace Product.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Name = "Products", Price = 100 });
        }
    }
}
