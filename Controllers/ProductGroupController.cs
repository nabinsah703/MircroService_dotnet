using Microsoft.AspNetCore.Mvc;
using Product.DbLogic;
using Product.Models;

namespace Product.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductGroupController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductGroupController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ProductGroup> ProductGroup = _context.productGroups.ToList();
            return Ok(ProductGroup);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            ProductGroup productGroup = _context.productGroups.FirstOrDefault(x => x.ID == id)!;
            if (productGroup == null)
            {
                return BadRequest($"No Product group with id {id} available");
            }
            return Ok(productGroup);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductGroup productGroup)
        {
            try
            {
                if (productGroup == null)
                {
                    return BadRequest("No Data available");
                }
                _context.productGroups.Add(productGroup);
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Product group added successfully", productGroup = productGroup });

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put(ProductGroup productGroup)
        {
            if (productGroup.ID == 0)
            {
                return BadRequest("no item is available to update!");
            }
            try
            {
                productGroup.ProductGroupName = productGroup.ProductGroupName;
                productGroup.ProductGroupCode = productGroup.ProductGroupCode;
                productGroup.Remarks = productGroup.Remarks;
                _context.productGroups.Update(productGroup);
                await _context.SaveChangesAsync();
                return Ok("Product group updated successfully!");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var product = _context.productGroups.FirstOrDefault(x=>x.ID ==id);
            if(product == null)
            {
                return BadRequest($"No Item with id {id} to be deleted!"); ;
            }
            _context.productGroups.Remove(product!);
            _context.SaveChanges();
            return Ok("Product group deleted successfully!");
        }
    }
}
