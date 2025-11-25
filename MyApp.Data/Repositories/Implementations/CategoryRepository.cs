using MyApp.Data.Data;
using MyApp.Data.Entities;
using MyApp.Data.Repositories.Interfaces;

namespace MyApp.Data.Repositories.Implementations
{
    public class CategoryRepository(AppDbContext context) : ICategoryRepository
    {
        private readonly AppDbContext _context = context;

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> CreateAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
