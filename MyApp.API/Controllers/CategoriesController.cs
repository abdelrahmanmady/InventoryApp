using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto dto)
        {

        }
    }
}
