using Microsoft.EntityFrameworkCore;
using Tech_Store_Product_Service_Domain.Abstractions;
using Tech_Store_Product_Service_Domain.Entities;
using Tech_Store_Product_Service_Infrastructure.DataContexts;

namespace Tech_Store_Product_Service_Infrastructure.Repositories;

public sealed class ProductRepository(ApplicationContext context) : IProductRepository
{
    private readonly ApplicationContext _context = context;

    public Task<Product?> GetByIdAsync(Guid id)
    {
        return _context.Products.SingleOrDefaultAsync(product => product.Id == id);
    }

    public Task<List<Product>> GetAllAsync()
    {
        return _context.Products.ToListAsync();
    }

    public void Add(Product product)
    {
        _context.Products.Add(product);
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
    }

    public void Remove(Product product)
    { 
        _context.Products.Remove(product);
    }
}