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
        private readonly ICommerceRepository<Products> _commerceRepository;
        public ProductsController(IProductRepository productRepository, ICommerceRepository<Products> commerceRepository)
        {
            _productRepository = productRepository;
            _commerceRepository = commerceRepository;
        }

        [HttpGet]

        public async Task<ActionResult<ProductResponseDTO>> GetProductsAsync()
        {
            var products = await _commerceRepository.GetAllAsync();
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
            var product = await _commerceRepository.GetOnlyOne(s => s.ProductID == id);
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

        [HttpGet("{name:alpha}")]
        public async Task<ActionResult<ProductResponseDTO>> GetProductsByName(string name)
        {
            var filteredProducts = await _commerceRepository.GetFiltered(s => s.ProductName.ToLower().Contains(name.ToLower()));
            if (filteredProducts == null)
                return NotFound($"product not found!");

            var productsDTO = filteredProducts.Select(product => new ProductResponseDTO()
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
        [HttpGet]
        [Route("Category/{id}")]
        public async Task<ActionResult<ProductResponseDTO>> GetProductsByCategory(int id)
        {
            var filteredProducts = await _commerceRepository.GetFiltered(s => s.CategoryID == id);
            if (filteredProducts == null)
                return NotFound($"product not found!");

            var productsDTO = filteredProducts.Select(product => new ProductResponseDTO()
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

        [HttpPatch]
        [Route("EditProduct")]
        public async Task<ActionResult> UpdateProductAsync([FromBody] CreateProductDTO model)
        {
            var selectedProduct = await _commerceRepository.GetOnlyOne(s => s.ProductID == model.ProductID);

            if (selectedProduct == null)
                return NotFound($"product with id {model.ProductID} not found"); 

            selectedProduct.ProductName = model.ProductName;
            selectedProduct.CategoryID = model.CategoryID;
            selectedProduct.Count = model.Count;
            selectedProduct.Price = model.Price;
            selectedProduct.Description = model.Description;

            await _commerceRepository.UpdateAsync(selectedProduct);

            return Ok("record updated successfully");
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> CreateProductAsync([FromBody] CreateProductDTO model)
        {
            try
            {
                if (model == null)
                    return BadRequest("No product to ceate");
                var product = new Products { ProductName = model.ProductName, CategoryID = model.CategoryID, Price = model.Price, Count = model.Count, Description = model.Description };

                Products newproduct = await _commerceRepository.CreateAsync(product);
             
                return CreatedAtAction(nameof(GetProductByIdAsync), new { id = newproduct.ProductID }, newproduct);
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Server Error" });
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProductAsync(int id)
        {
            var productToDelete = await _commerceRepository.GetOnlyOne(p => p.ProductID == id);
            if (productToDelete == null)
                return NotFound("Product not found!");

            await _commerceRepository.DeleteAsync(productToDelete);

            return NoContent();
        }

    }
}
