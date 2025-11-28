using MediatR;
using MyApp.Data.Entities;
using MyApp.Data.Repositories.Interfaces;

namespace MyApp.Application.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler(IProductRepository products) : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _products = products;
        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _products.GetAllAsync();
        }
    }
}
