using MediatR;

namespace MyApp.Application.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(
        int Id,
        string? Name,
        string? Description,
        decimal? Price,
        byte[]? Image,
        int? CategoryId
        ) : IRequest<bool>;

}
