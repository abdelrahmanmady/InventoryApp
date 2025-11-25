using MyApp.Data.Entities;

namespace MyApp.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<bool> CreateAsync(Product category);
        Task<bool> UpdateAsync(Product category);
        Task<bool> DeleteAsync(int id);
    }
}
