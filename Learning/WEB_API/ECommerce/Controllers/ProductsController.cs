using System.Threading.Tasks;
using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly EcommerceDBContext _context;
        public ProductsController(EcommerceDBContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<Products>> GetProducts()
        {
            var products = _context.Products.Select(product => new ProductDTO()
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                CategoryName = _context.Categories.First(x => x.CategoryID == product.CategoryID).CategoryName,
                Price = product.Price,
                Count = product.Count,
                Description = product.Description
            });
            return Ok(await products.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid entry!");
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound($"product with id {id} not found!");

            var productDTO = new ProductDTO
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                CategoryName = _context.Categories.First(x => x.CategoryID == product.CategoryID).CategoryName,
                Price = product.Price,
                Count = product.Count,
                Description = product.Description
            };
            return Ok(productDTO);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid entry!");
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound($"item with id {id} not found");

            var ProductDTO = new ProductDTO
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                CategoryName = _context.Categories.First(x => x.CategoryID == product.CategoryID).CategoryName,
                Price = product.Price,
                Count = product.Count,
                Description = product.Description
            };
            return Ok("record updated successfully");
        }
       

    }
}
