using System.Threading.Tasks;
using AutoMapper;
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
        public readonly IMapper _mapper;
        private readonly EcommerceDBContext _context;
        public ProductsController(EcommerceDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<CreateProductDTO>> GetProductsAsync()
        {
            var products = _context.Products.ToListAsync();
            var productDTOData = _mapper.Map<List<CreateProductDTO>>(products);
            return Ok(productDTOData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDTO>> GetProductByIdAsync(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid entry!");
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound($"product with id {id} not found!");

            var productDTO = new ProductResponseDTO
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

        [HttpPatch]
        [Route("EditProduct")]
        public async Task<ActionResult> UpdateProductAsync([FromBody] CreateProductDTO model)
        {
            var selectedProduct = await _context.Products.FirstOrDefaultAsync(x => x.ProductID == model.ProductID);
            if (selectedProduct == null)
                return NotFound($"product with id {model.ProductID} not found");
            if (_context.Categories.FirstOrDefault(x => x.CategoryID == model.CategoryID) == null)
            {
                return BadRequest("Invalid category ID");
            }

            selectedProduct.ProductName = model.ProductName;
            selectedProduct.CategoryID = model.CategoryID;
            selectedProduct.Price = model.Price;
            selectedProduct.Count = model.Count;
            selectedProduct.Description = model.Description;


            return Ok("record updated successfully");
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> CreateProductAsync([FromBody] CreateProductDTO model)
        {
            // int newID = _context.Products.OrderBy(x=>x.ProductID).LastOrDefault().ProductID+1;

            var product = new Products { ProductName = model.ProductName, CategoryID = model.CategoryID, Price = model.Price, Count = model.Count, Description = model.Description };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            model.ProductID = product.ProductID;

            return CreatedAtAction(nameof(GetProductByIdAsync), new { id = model.ProductID }, model);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (id <= 0)
                return BadRequest("Invalid ID!");
            if (product == null)
                return NotFound();

            _context.Products.Remove(product);  
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
