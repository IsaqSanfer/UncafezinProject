using Microsoft.EntityFrameworkCore;
using Uncafezin.WebAppUltimate.Data;
using Uncafezin.WebAppUltimate.Entities;

namespace Uncafezin.WebAppUltimate.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly UncafezinContext _context;
    public ProductRepository(UncafezinContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _context.ProductTab.ToListAsync();
    }

    public async Task<Product> GetProductById(int id)
    {
        return await _context.ProductTab.Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Product> CreateProduct(Product product)
    {
        _context.ProductTab.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> DeleteProduct(int id)
    {
        var product = await GetProductById(id);
        _context.ProductTab.Remove(product);
        await _context.SaveChangesAsync();
        return product;
    }
}
