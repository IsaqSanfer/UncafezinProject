using Uncafezin.ProductAPI.Data;
using Uncafezin.ProductAPI.Models;

namespace Uncafezin.ProductAPI.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ProductAPIContext _context;
    public CategoryRepository(ProductAPIContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<Category>> GetAllCategories()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetCategoriesProducts()
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetCategoryById(int id)
    {
        throw new NotImplementedException();
    }
    public Task<Category> CreateCategory(Category category)
    {
        throw new NotImplementedException();
    }

    public Task<Category> UpdateCategory(Category category)
    {
        throw new NotImplementedException();
    }

    public Task<Category> DeleteCategory(int id)
    {
        throw new NotImplementedException();
    }
}
