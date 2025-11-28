using MediatR;

namespace MyApp.Application.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(int Id) : IRequest<bool>;
}
