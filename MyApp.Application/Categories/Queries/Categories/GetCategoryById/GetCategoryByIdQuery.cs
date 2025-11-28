using MediatR;
using MyApp.Data.Entities;

namespace MyApp.Application.Categories.Queries.Categories.GetCategoryById
{
    public record GetCategoryByIdQuery(int Id) : IRequest<Category?>;
}
