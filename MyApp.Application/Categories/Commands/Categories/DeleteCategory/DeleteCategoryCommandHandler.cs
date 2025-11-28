using MediatR;
using MyApp.Data.Repositories.Interfaces;

namespace MyApp.Application.Categories.Commands.Categories.DeleteCategory
{
    public class DeleteCategoryCommandHandler(ICategoryRepository categories) : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categories = categories;
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _categories.DeleteAsync(request.Id);
        }
    }
}
