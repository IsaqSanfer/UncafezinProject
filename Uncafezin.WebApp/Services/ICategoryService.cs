using Uncafezin.WebApp.Models;

namespace Uncafezin.WebApp.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryViewModel>> GetAllCategories();
}