using MediatR;
using MyApp.Data.Repositories.Interfaces;

namespace MyApp.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler(IProductRepository products) : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _products = products;

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _products.DeleteAsync(request.Id);
        }
    }
}
