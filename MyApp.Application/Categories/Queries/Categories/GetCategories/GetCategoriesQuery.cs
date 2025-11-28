using MediatR;
using MyApp.Data.Entities;

namespace MyApp.Application.Categories.Queries.Categories.GetCategories
{
    public record GetCategoriesQuery : IRequest<IEnumerable<Category>>;
}
