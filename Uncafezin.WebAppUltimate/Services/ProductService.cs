using Uncafezin.WebAppUltimate.Entities;
using Uncafezin.WebAppUltimate.Models;
using Uncafezin.WebAppUltimate.Repositories;

namespace Uncafezin.WebAppUltimate.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    public ProductService(IProductRepository productRepository)
    {
        _repository = productRepository;
    }

    private ProductViewModel MapProduct(Product p)
    {
        return new ProductViewModel
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Description = p.Description,
            ImgUrl = p.ImgUrl,
            Stock = p.Stock,
            CategoryId = p.CategoryId,
            CategoryName = p.CategoryName
        };
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllProducts()
    {
        var entity = await _repository.GetAllProducts();

        var products = entity.Select(p => new ProductViewModel
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Description = p.Description,
            ImgUrl = p.ImgUrl,
            Stock = p.Stock,
            CategoryId = p.CategoryId,
            CategoryName = p.CategoryName
        });
        return products;
    }

    public async Task<ProductViewModel> GetProductById(int id)
    {
        var entity = await _repository.GetProductById(id);

        var product = new ProductViewModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price,
            Description = entity.Description,
            Stock = entity.Stock,
            ImgUrl = entity.ImgUrl,
            CategoryId = entity.CategoryId,
            CategoryName = entity.CategoryName
        };
        return product;
    }

    public async Task CreateProduct(ProductViewModel productViewModel)
    {
        var entity = new Product
        {
            Id = productViewModel.Id,
            Name = productViewModel.Name,
            Price = productViewModel.Price,
            Description = productViewModel.Description,
            Stock = productViewModel.Stock,
            ImgUrl = productViewModel.ImgUrl,
            CategoryId = productViewModel.CategoryId,
            CategoryName = productViewModel.CategoryName
        };
        await _repository.CreateProduct(entity);
    }

    public async Task UpdateProduct(ProductViewModel productViewModel)
    {
        var entity = new Product
        {
            Id = productViewModel.Id,
            Name = productViewModel.Name,
            Price = productViewModel.Price,
            Description = productViewModel.Description,
            Stock = productViewModel.Stock,
            ImgUrl = productViewModel.ImgUrl,
            CategoryId = productViewModel.CategoryId,
            CategoryName = productViewModel.CategoryName
        };
        await _repository.UpdateProduct(entity);
    }

    public async Task DeleteProduct(int id)
    {
        var entity = _repository.GetProductById(id).Result;
        await _repository.DeleteProduct(entity.Id);
    }
}
