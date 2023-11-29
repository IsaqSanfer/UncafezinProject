using Uncafezin.WebApp.Models;

namespace Uncafezin.WebApp.Services;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> GetAllProducts();
    Task<ProductViewModel> GetProductById(int id);
    Task<ProductViewModel> CreateProduct(ProductViewModel productViewModel);
    Task<ProductViewModel> UpdateProduct(ProductViewModel productViewModel);
    Task<bool> DeleteProduct(int id);
}
