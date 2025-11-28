using MediatR;

namespace MyApp.Application.Categories.Commands.Categories.CreateCategory
{
    public record CreateCategoryCommand(string Name, string? Description) : IRequest<(bool, int)>;
}
