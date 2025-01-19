using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
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

        [HttpGet("{id}")]
        public IActionResult GetByProductID(int id)
        {
            Products products = _context.products.FirstOrDefault(x => x.ID == id)!;
            if (products == null)
            {
                return BadRequest($"No Product Available With {id} ID.");
            }
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

        [HttpPut]
        public async Task<IActionResult> EditProduct(Products products)
        {
            Products product = _context.products.FirstOrDefault(p => p.ID == products.ID)!;
            if (product == null)
            {
                return BadRequest($"Product with id {products.ID} is not available.");
            }

            product.ProductName = products.ProductName;
            product.ProductDescription = products.ProductDescription;
            product.ProductCount = products.ProductCount;
            product.Price = products.Price;
            product.ProductCategoryID = products.ProductCategoryID;
            product.Quantity = products.Quantity;
            
            _context.products.Update(product);
            await _context.SaveChangesAsync();
            return Ok("Product updated successfully");


        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var products = _context.products.FirstOrDefault(p => p.ID == id);
            if (products == null)
            {
                return BadRequest($"Product with ID {id} is not available.");
            }
            _context.products.Remove(products);
            _context.SaveChanges();
            return Ok(new { Message = "Product Deleted Successfully" });
        }
    }
}
