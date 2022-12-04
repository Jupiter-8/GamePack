using GamePack.DataAccess;
using GamePack.Domain.Entities;
using GamePack.Services.Interfaces;

namespace GamePack.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _dbContext;

        public CategoryService(AppDbContext dbContext)
            => _dbContext = dbContext;

        public List<Category> GetCategories() => _dbContext.Categories.ToList();
    }
}
