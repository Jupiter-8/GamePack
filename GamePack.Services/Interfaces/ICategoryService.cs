using GamePack.Domain.Entities;

namespace GamePack.Services.Interfaces
{
    public interface ICategoryService
    {
        public List<Category> GetCategories();
    }
}
