using MediatR;
using MyApp.Data.Entities;
using MyApp.Data.Repositories.Interfaces;

namespace MyApp.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler(IProductRepository products, ICategoryRepository categories) : IRequestHandler<CreateProductCommand, (bool, int)>
    {
        private readonly IProductRepository _products = products;
        private readonly ICategoryRepository _categories = categories;
        public async Task<(bool, int)> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var categoryExists = await _categories.ExistsAsync(request.CategoryId);
            if (!categoryExists)
                return (false, 0);
            Product productToCreate = new()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Image = request.Image,
                CategoryId = request.CategoryId
            };
            return await _products.CreateAsync(productToCreate);
        }
    }
}
