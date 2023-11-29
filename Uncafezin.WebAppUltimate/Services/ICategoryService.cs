using Uncafezin.WebAppUltimate.Models;

namespace Uncafezin.WebAppUltimate.Services;

public interface ICategoryService
{
    //Trabalhar com as informações para as Models
    Task<IEnumerable<CategoryViewModel>> GetAllCategories();
    Task<IEnumerable<CategoryViewModel>> GetCategoriesProducts();
    Task<CategoryViewModel> GetCategoryById(int id);
    Task AddCategory(CategoryViewModel categoryViewModel);
    Task UpdateCategory(CategoryViewModel categoryViewModel);
    Task DeleteCategory(int id);
}
