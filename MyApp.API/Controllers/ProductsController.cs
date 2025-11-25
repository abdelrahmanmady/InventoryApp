using Microsoft.AspNetCore.Mvc;
using MyApp.API.DTOs.ProductDTOs;
using MyApp.Data.Entities;
using MyApp.Data.Repositories.Interfaces;

namespace MyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductRepository products, ICategoryRepository categories) : ControllerBase
    {
        private readonly IProductRepository _products = products;
        private readonly ICategoryRepository _categories = categories;

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _products.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = await _products.GetByIdAsync(id);
            if (product == null)
                return NotFound("Invalid Product ID");
            return Ok(product);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateProduct([FromForm] ProductCreateDTO dto)
        {
            var categoryExists = await _categories.ExistsAsync(dto.CategoryId!.Value);
            if (!categoryExists)
            {
                ModelState.AddModelError(nameof(dto.CategoryId), "Category ID Invalid");
                return ValidationProblem();
            }

            byte[]? bytes = null;
            if (dto.Image is not null)
            {
                using var stream = new MemoryStream();
                await dto.Image.CopyToAsync(stream);
                bytes = stream.ToArray();
            }

            Product productToCreate = new()
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price!.Value,
                Image = bytes,
                CategoryId = dto.CategoryId.Value
            };
            var (isCreated, id) = await _products.CreateAsync(productToCreate);
            if (!isCreated)
                return BadRequest("Error Creating Product..");
            return Ok($"Product with id {id} Created");
        }

        [HttpPut("{id:int}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromForm] ProductUpdateDto dto)
        {
            var productToUpdate = await _products.GetByIdAsync(id);
            if (productToUpdate is null)
                return NotFound("Invalid Product ID");

            if (dto.CategoryId is not null)
            {
                var categoryExists = await _categories.ExistsAsync(dto.CategoryId!.Value);
                if (!categoryExists)
                {
                    ModelState.AddModelError(nameof(dto.CategoryId), "Category ID Invalid");
                    return ValidationProblem();
                }
            }

            byte[]? bytes = null;
            if (dto.Image is not null)
            {
                using var stream = new MemoryStream();
                await dto.Image.CopyToAsync(stream);
                bytes = stream.ToArray();
            }
            productToUpdate.Name = dto.Name ?? productToUpdate.Name;
            productToUpdate.Description = dto.Description ?? productToUpdate.Description;
            productToUpdate.Price = dto.Price ?? productToUpdate.Price;
            productToUpdate.Image = bytes ?? productToUpdate.Image;
            productToUpdate.CategoryId = dto.CategoryId ?? productToUpdate.CategoryId;

            var isUpdated = await _products.UpdateAsync(productToUpdate);
            if (!isUpdated)
                return BadRequest("Error Updating Product..");

            return Ok($"Product with id {productToUpdate.Id} Updated");

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var isDeleted = await _products.DeleteAsync(id);
            if (!isDeleted)
                return BadRequest("Error Deleting Product..");
            return Ok($"Product with id {id} Deleted");
        }



    }
}
