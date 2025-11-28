using MediatR;
using MyApp.Data.Entities;
using MyApp.Data.Repositories.Interfaces;

namespace MyApp.Application.Categories.Commands.Categories.CreateCategory
{
    public class CreateCategoryCommandHandler(ICategoryRepository categories) : IRequestHandler<CreateCategoryCommand, (bool, int)>
    {
        private readonly ICategoryRepository _categories = categories;
        public async Task<(bool, int)> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category categoryToCreate = new()
            {
                Name = request.Name,
                Description = request.Description,
            };
            return await _categories.CreateAsync(categoryToCreate);
        }
    }
}
