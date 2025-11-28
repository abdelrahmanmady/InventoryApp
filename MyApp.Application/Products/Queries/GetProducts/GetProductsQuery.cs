using MediatR;
using MyApp.Data.Entities;

namespace MyApp.Application.Products.Queries.GetProducts
{
    public record GetProductsQuery : IRequest<IEnumerable<Product>>;


}
