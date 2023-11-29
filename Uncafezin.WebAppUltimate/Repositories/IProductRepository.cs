using Uncafezin.WebAppUltimate.Entities;

namespace Uncafezin.WebAppUltimate.Repositories;

public interface IProductRepository
{
    //Trabalhar com as Entities para o BD (através da classe contexto)
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product> GetProductById(int id);
    Task<Product> CreateProduct(Product product);
    Task<Product> UpdateProduct(Product product);
    Task<Product> DeleteProduct(int id);
}
