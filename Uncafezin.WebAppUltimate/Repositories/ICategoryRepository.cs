using Uncafezin.WebAppUltimate.Entities;

namespace Uncafezin.WebAppUltimate.Repositories;

public interface ICategoryRepository
{
    //Trabalhar com as Entities para o BD (através da classe contexto)
    Task<IEnumerable<Category>> GetAllCategories();
    Task<IEnumerable<Category>> GetCategoriesProducts();
    Task<Category> GetCategoryById(int id);
    Task<Category> CreateCategory(Category category);
    Task<Category> UpdateCategory(Category category);
    Task<Category> DeleteCategory(int id);
}
