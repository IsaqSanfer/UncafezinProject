using Uncafezin.WebAppUltimate.Models;

namespace Uncafezin.WebAppUltimate.Services;

public interface IProductService
{
    //Trabalhar com as informações para as Models
    Task<IEnumerable<ProductViewModel>> GetAllProducts();
    Task<ProductViewModel> GetProductById(int id);
    Task CreateProduct(ProductViewModel productViewModel);
    Task UpdateProduct(ProductViewModel productViewModel);
    Task DeleteProduct(int id);
}
