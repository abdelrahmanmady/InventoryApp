using Microsoft.AspNetCore.Mvc;
using MyApp.API.DTOs.CategoryDTOs;
using MyApp.Data.Entities;
using MyApp.Data.Repositories.Interfaces;

namespace MyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryRepository categories) : ControllerBase
    {
        private readonly ICategoryRepository _categories = categories;

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _categories.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var category = await _categories.GetByIdAsync(id);
            if (category == null)
                return NotFound("Invalid Category ID");
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto dto)
        {
            Category categoryToCreate = new()
            {
                Name = dto.Name,
                Description = dto.Description
            };
            var (isCreated, id) = await _categories.CreateAsync(categoryToCreate);
            if (!isCreated)
                return BadRequest("Error Creating Category..");
            return Ok($"Category with id {id} Created");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] CategoryUpdateDto dto)
        {
            var categoryToUpdate = await _categories.GetByIdAsync(id);
            if (categoryToUpdate == null)
                return NotFound("Invalid Category ID");

            categoryToUpdate.Name = dto.Name ?? categoryToUpdate.Name;
            categoryToUpdate.Description = dto.Description ?? categoryToUpdate.Description;
            var isUpdated = await _categories.UpdateAsync(categoryToUpdate);

            if (!isUpdated)
                return BadRequest("Error Updating Category..");
            return Ok($"Category with  id {categoryToUpdate.Id} Updated");

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var isDeleted = await _categories.DeleteAsync(id);
            if (!isDeleted)
                return BadRequest("Error Deleting Category..");
            return Ok($"Category with id {id} Deleted");
        }
    }
}
