using System.Threading.Tasks;
using ECommerce.DTOs;
using ECommerce.Models;
using ECommerce.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICommerceRepository<Category> _commerceRepository;
        public CategoryController(ICommerceRepository<Category> commerceRepository)
        {
            _commerceRepository = commerceRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CategoriesDTO>> GetAllCategories()
        {
            try
            {
                var categories = await _commerceRepository.GetAllAsync();
                var categoriesDTO = categories.Select(c => new CategoriesDTO()
                {
                    CategoryID = c.CategoryID,
                    CategoryName = c.CategoryName,
                    Description = c.Description
                });

                return Ok(categoriesDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Server Error" });
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoriesDTO>> GetCategoryByID(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid entry");

                var category = await _commerceRepository.GetOnlyOne(x => x.CategoryID == id);

                if (category == null)
                    return NotFound("category not found!");

                var categoryDTO = new CategoriesDTO
                {
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName,
                    Description = category.Description
                };
                return Ok(categoryDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Server Error" });
            }
        }

        [HttpGet("{name:alpha}")]
        public async Task<ActionResult<CategoriesDTO>> GetCategoryByName(string name)
        {
            try
            {
                var category = await _commerceRepository.GetOnlyOne(x => x.CategoryName.ToLower().Contains(name.ToLower()));
                if (category == null)
                    return NotFound("category not found!");
                var categoryDTO = new CategoriesDTO
                {
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName,
                    Description = category.Description
                };
                return Ok(categoryDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Server Error" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] CategoriesDTO model)
        {
            try
            {
                var category = new Category { CategoryName = model.CategoryName, Description = model.Description };
                var newCategory = await _commerceRepository.CreateAsync(category);

                return CreatedAtAction(nameof(GetCategoryByID), new { id = newCategory.CategoryID }, newCategory);
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Server error" });
            }
        }
        [HttpPatch]
        public async Task<ActionResult> UpdateCategory([FromBody] CategoriesDTO model)
        {
            try
            {
                var categoryToUpdate = await _commerceRepository.GetOnlyOne(c => c.CategoryID == model.CategoryID);
                if (categoryToUpdate == null)
                    return NotFound("Product not found!");
                categoryToUpdate.CategoryName = model.CategoryName;
                categoryToUpdate.Description = model.Description;

                await _commerceRepository.UpdateAsync(categoryToUpdate);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Server Error" });
            }

        }

        [HttpDelete]
        public async Task<ActionResult> DeletCategory(int id)
        {
            var productToDelete = await _commerceRepository.GetOnlyOne(c => c.CategoryID == id);
            if (productToDelete == null)
                return NotFound("Product not found");

            await _commerceRepository.DeleteAsync(productToDelete);

            return NoContent();
        }
    }
}