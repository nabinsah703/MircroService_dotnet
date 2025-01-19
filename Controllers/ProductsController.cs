using Microsoft.AspNetCore.Mvc;
using Product.DbLogic;
using Product.Models;

namespace Product.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Products> products = _context.products.ToList();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Products products)
        {
            if (products == null)
            {
                return BadRequest("Product is null");
            }
            try
            {
                _context.products.Add(products);
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Product Created Successfully!", Product = products });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }

        }
    }
}
