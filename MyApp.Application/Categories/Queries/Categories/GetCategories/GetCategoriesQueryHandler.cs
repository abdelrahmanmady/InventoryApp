using MediatR;
using MyApp.Data.Entities;
using MyApp.Data.Repositories.Interfaces;

namespace MyApp.Application.Categories.Queries.Categories.GetCategories
{
    public class GetCategoriesQueryHandler(ICategoryRepository categories) : IRequestHandler<GetCategoriesQuery, IEnumerable<Category>>
    {
        private readonly ICategoryRepository _categories = categories;
        public async Task<IEnumerable<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _categories.GetAllAsync();
        }
    }
}
