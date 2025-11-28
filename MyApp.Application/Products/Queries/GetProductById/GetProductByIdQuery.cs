using MediatR;
using MyApp.Data.Entities;

namespace MyApp.Application.Products.Queries.GetProductById
{
    public record GetProductByIdQuery(int Id) : IRequest<Product?>;
}
