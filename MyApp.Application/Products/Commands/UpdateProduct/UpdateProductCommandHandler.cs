using MediatR;
using MyApp.Data.Repositories.Interfaces;

namespace MyApp.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler(IProductRepository products, ICategoryRepository categories) : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _products = products;
        private readonly ICategoryRepository _categories = categories;
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _products.GetByIdAsync(request.Id);
            if (productToUpdate is null)
                return false;
            if (request.CategoryId is not null)
            {
                var categoryExists = await _categories.ExistsAsync(request.CategoryId.Value);
                if (!categoryExists)
                    return false;
            }

            productToUpdate.Name = request.Name ?? productToUpdate.Name;
            productToUpdate.Description = request.Description ?? productToUpdate.Description;
            productToUpdate.Price = request.Price ?? productToUpdate.Price;
            productToUpdate.Image = request.Image ?? productToUpdate.Image;
            productToUpdate.CategoryId = request.CategoryId ?? productToUpdate.CategoryId;

            return await _products.UpdateAsync(productToUpdate);

        }
    }
}
