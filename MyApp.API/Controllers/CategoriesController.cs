using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.API.DTOs.CategoryDTOs;
using MyApp.Application.Categories.Commands.Categories.CreateCategory;
using MyApp.Application.Categories.Commands.Categories.DeleteCategory;
using MyApp.Application.Categories.Commands.Categories.UpdateCategory;
using MyApp.Application.Categories.Queries.Categories.GetCategories;
using MyApp.Application.Categories.Queries.Categories.GetCategoryById;

namespace MyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;


        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _sender.Send(new GetCategoriesQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var category = await _sender.Send(new GetCategoryByIdQuery(id));
            if (category == null)
                return NotFound("Invalid Category ID");
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {

            var (isCreated, id) = await _sender.Send(command);
            if (!isCreated)
                return BadRequest("Error Creating Category..");
            return Ok($"Category with id {id} Created");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] CategoryUpdateDto dto)
        {

            var isUpdated = await _sender.Send(new UpdateCategoryCommand(id, dto.Name, dto.Description));
            if (!isUpdated)
                return BadRequest("Error Updating Category..");
            return Ok($"Category with  id {id} Updated");

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var isDeleted = await _sender.Send(new DeleteCategoryCommand(id));
            if (!isDeleted)
                return BadRequest("Error Deleting Category..");
            return Ok($"Category with id {id} Deleted");
        }
    }
}
