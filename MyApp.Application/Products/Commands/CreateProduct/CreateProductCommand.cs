using MediatR;

namespace MyApp.Application.Products.Commands.CreateProduct
{
    public record CreateProductCommand(
            string Name,
            string? Description,
            decimal Price,
            byte[]? Image,
            int CategoryId) : IRequest<(bool, int)>;
}
