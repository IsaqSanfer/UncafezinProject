using Uncafezin.ProductAPI.Models;

namespace Uncafezin.ProductAPI.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategories();
    Task<IEnumerable<Category>> GetCategoriesProducts();
    Task<Category> GetCategoryById(int id);
    //Task<Category> GetCategoryByName(string name);
    Task<Category> CreateCategory(Category category);
    Task<Category> UpdateCategory(Category category);
    Task<Category> DeleteCategory(int id);
}
