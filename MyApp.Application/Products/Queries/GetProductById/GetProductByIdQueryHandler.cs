using MediatR;
using MyApp.Data.Entities;
using MyApp.Data.Repositories.Interfaces;

namespace MyApp.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler(IProductRepository products) : IRequestHandler<GetProductByIdQuery, Product?>
    {
        private readonly IProductRepository _products = products;
        public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _products.GetByIdAsync(request.Id);
        }
    }
}
