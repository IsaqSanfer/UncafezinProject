using Uncafezin.WebAppUltimate.Entities;
using Uncafezin.WebAppUltimate.Models;
using Uncafezin.WebAppUltimate.Repositories;

namespace Uncafezin.WebAppUltimate.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _repository = categoryRepository;
    }

    private CategoryViewModel MapCategory(Category c)
    {
        return new CategoryViewModel
        {
            CategoryId = c.CategoryId,
            CategoryName = c.CategoryName
        };
    }

    public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
    {
        var entity = await _repository.GetAllCategories();

        var categories = entity.Select(c => new CategoryViewModel
        {
            CategoryId = c.CategoryId,
            CategoryName = c.CategoryName,
        });
        return categories;  
    }

    public async Task<IEnumerable<CategoryViewModel>> GetCategoriesProducts()
    {   //revisar este método posteriormente!!!
        var entity = await _repository.GetCategoriesProducts();

        var categories = entity.Select(c => new CategoryViewModel
        {
            CategoryId = c.CategoryId,
            CategoryName = c.CategoryName,
        });
        return categories;
    }

    public async Task<CategoryViewModel> GetCategoryById(int id)
    {
        var entity = await _repository.GetCategoryById(id);

        var category = new CategoryViewModel
        {
            CategoryId = entity.CategoryId,
            CategoryName = entity.CategoryName,
        };
        return category;
    }

    public async Task AddCategory(CategoryViewModel categoryViewModel)
    {
        var entity = new Category
        {
            CategoryId = categoryViewModel.CategoryId,
            CategoryName = categoryViewModel.CategoryName,
        };

        await _repository.CreateCategory(entity);
    }

    public async Task UpdateCategory(CategoryViewModel categoryViewModel)
    {
        var entity = new Category
        {
            CategoryId = categoryViewModel.CategoryId,
            CategoryName = categoryViewModel.CategoryName,
        };

        await _repository.UpdateCategory(entity);
    }

    public async Task DeleteCategory(int id)
    {
        var entity = _repository.GetCategoryById(id).Result;
        await _repository.DeleteCategory(entity.CategoryId);
    }
}
