using Microsoft.EntityFrameworkCore;
using Uncafezin.WebAppUltimate.Data;
using Uncafezin.WebAppUltimate.Entities;

namespace Uncafezin.WebAppUltimate.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly UncafezinContext _context;
    public CategoryRepository(UncafezinContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        return await _context.CategoryTab.ToListAsync();
    }

    public async Task<IEnumerable<Category>> GetCategoriesProducts()
    {
        return await _context.CategoryTab.Include(p => p.Products).ToListAsync();
    }

    public async Task<Category> GetCategoryById(int id)
    {
        return await _context.CategoryTab.Where(c => c.CategoryId == id).FirstOrDefaultAsync();
    }

    public async Task<Category> CreateCategory(Category category)
    {
        _context.CategoryTab.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateCategory(Category category)
    {
        _context.Entry(category).State = EntityState.Modified; //atualização mais profunda inclusive propriedades de navegação
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> DeleteCategory(int id)
    {
        var category = await GetCategoryById(id);

        _context.CategoryTab.Remove(category);
        await _context.SaveChangesAsync();
        return category;
    }
}
