using MediatR;

namespace MyApp.Application.Categories.Commands.Categories.UpdateCategory
{
    public record UpdateCategoryCommand(int Id, string? Name, string? Description) : IRequest<bool>;

}
