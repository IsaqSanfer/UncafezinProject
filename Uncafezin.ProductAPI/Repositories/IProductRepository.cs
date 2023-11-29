using Uncafezin.ProductAPI.Models;

namespace Uncafezin.ProductAPI.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product> GetProductById(int id);
    //Task<Product> GetProductByName(string name);
    Task<Product> CreateProduct(Product product);
    Task<Product> UpdateProduct(Product product);
    Task<Product> DeleteProduct(int id);
}
