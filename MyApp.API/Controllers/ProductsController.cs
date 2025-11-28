using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.API.DTOs.ProductDTOs;
using MyApp.Application.Products.Commands.CreateProduct;
using MyApp.Application.Products.Commands.DeleteProduct;
using MyApp.Application.Products.Commands.UpdateProduct;
using MyApp.Application.Products.Queries.GetProductById;
using MyApp.Application.Products.Queries.GetProducts;

namespace MyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _sender.Send(new GetProductsQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = await _sender.Send(new GetProductByIdQuery(id));
            if (product == null)
                return NotFound("Invalid Product ID");
            return Ok(product);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateProduct([FromForm] ProductCreateDTO dto)
        {
            var command = new CreateProductCommand
            (
                Name: dto.Name,
                Description: dto.Description,
                Price: dto.Price!.Value,
                Image: dto.Image is { Length: > 0 } ? await Serialize(dto.Image) : null,
                CategoryId: dto.CategoryId!.Value

            );
            var (isCreated, id) = await _sender.Send(command);
            if (!isCreated)
                return BadRequest("Error Creating Product..");
            return Ok($"Product with id {id} is Created");
        }

        [HttpPut("{id:int}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromForm] ProductUpdateDto dto)
        {
            var command = new UpdateProductCommand
                (
                id,
                Name: dto.Name,
                Description: dto.Description,
                Price: dto.Price,
                Image: dto.Image is { Length: > 0 } ? await Serialize(dto.Image) : null,
                CategoryId: dto.CategoryId
                );
            var isUpdated = await _sender.Send(command);
            if (!isUpdated)
                return BadRequest("Error Updating Product..");
            return Ok($"Product with id {id} is Updated");

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var isDeleted = await _sender.Send(new DeleteProductCommand(id));
            if (!isDeleted)
                return BadRequest("Error Deleting Product..");
            return Ok($"Product with id {id} Deleted");
        }


        private static async Task<byte[]> Serialize(IFormFile Image)
        {
            using var stream = new MemoryStream();
            await Image.CopyToAsync(stream);
            return stream.ToArray();
        }


    }
}
