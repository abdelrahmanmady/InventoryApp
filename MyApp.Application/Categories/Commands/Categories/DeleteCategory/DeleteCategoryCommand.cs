using MediatR;

namespace MyApp.Application.Categories.Commands.Categories.DeleteCategory
{
    public record DeleteCategoryCommand(int Id) : IRequest<bool>;

}
