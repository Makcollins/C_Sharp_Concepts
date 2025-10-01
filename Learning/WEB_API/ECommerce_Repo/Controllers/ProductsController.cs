using System.Threading.Tasks;
using ECommerce.Models;
using ECommerce.Repository;
using Microsoft.AspNetCore.Mvc;


namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ProductResponseDTO>> GetProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            var productsDTO = products.Select(product => new ProductResponseDTO()
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                CategoryID = product.CategoryID,
                Price = product.Price,
                Count = product.Count,
                Description = product.Description
            });
            return Ok(productsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDTO>> GetProductByIdAsync(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid entry!");
            var product = await _productRepository.GetByIDAsync(id);
            if (product == null)
                return NotFound($"product with id {id} not found!");

            var productDTO = new ProductResponseDTO
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                CategoryID = product.CategoryID,
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
            var selectedProduct = await _productRepository.GetByIDAsync(model.ProductID);

            if (selectedProduct == null)
                return NotFound($"product with id {model.ProductID} not found");

            selectedProduct.ProductName = model.ProductName;
            selectedProduct.CategoryID = model.CategoryID;
            selectedProduct.Count = model.Count;
            selectedProduct.Price = model.Price;
            selectedProduct.Description = model.Description;


            await _productRepository.UpdateAsync(selectedProduct);

            return Ok("record updated successfully");
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> CreateProductAsync([FromBody] CreateProductDTO model)
        {
            var product = new Products { ProductName = model.ProductName, CategoryID = model.CategoryID, Price = model.Price, Count = model.Count, Description = model.Description };

            model.ProductID = await _productRepository.CreateAsync(product);

            return CreatedAtAction(nameof(GetProductByIdAsync), new { id = model.ProductID }, model);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);

            return NoContent();
        }

    }
}
