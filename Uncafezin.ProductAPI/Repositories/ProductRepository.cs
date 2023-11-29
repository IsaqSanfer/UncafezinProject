using Uncafezin.ProductAPI.Data;
using Uncafezin.ProductAPI.Models;

namespace Uncafezin.ProductAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductAPIContext _context;
    public ProductRepository(ProductAPIContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<Product>> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProductById(int id)
    {
        throw new NotImplementedException();
    }
    public Task<Product> CreateProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<Product> UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<Product> DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }
}
