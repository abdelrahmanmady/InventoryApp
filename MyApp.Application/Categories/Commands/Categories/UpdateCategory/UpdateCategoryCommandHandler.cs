using MediatR;
using MyApp.Data.Repositories.Interfaces;

namespace MyApp.Application.Categories.Commands.Categories.UpdateCategory
{
    public class UpdateCategoryCommandHandler(ICategoryRepository categories) : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categories = categories;
        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToUpdate = await _categories.GetByIdAsync(request.Id);
            if (categoryToUpdate is null)
            {
                return false;
            }
            categoryToUpdate.Name = request.Name ?? categoryToUpdate.Name;
            categoryToUpdate.Description = request.Description ?? categoryToUpdate.Description;
            return await _categories.UpdateAsync(categoryToUpdate);

        }
    }
}
