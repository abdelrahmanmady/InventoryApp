using MediatR;
using MyApp.Data.Entities;
using MyApp.Data.Repositories.Interfaces;

namespace MyApp.Application.Categories.Queries.Categories.GetCategoryById
{
    public class GetCategryByIdQueryHandler(ICategoryRepository categories) : IRequestHandler<GetCategoryByIdQuery, Category?>
    {
        private readonly ICategoryRepository _categories = categories;
        public async Task<Category?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _categories.GetByIdAsync(request.Id);
        }
    }
}
