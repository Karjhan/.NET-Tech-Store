using Microsoft.EntityFrameworkCore;
using Tech_Store_Product_Service_Domain.Abstractions;
using Tech_Store_Product_Service_Domain.Entities;
using Tech_Store_Product_Service_Infrastructure.DataContexts;

namespace Tech_Store_Product_Service_Infrastructure.Repositories;

public class ProductTypeRepository : IProductTypeRepository
{
    private readonly ApplicationContext _context;

    public ProductTypeRepository(ApplicationContext context)
    {
        _context = context;
    }

    public Task<ProductType?> GetByIdAsync(Guid id)
    {
        return _context.ProductTypes.SingleOrDefaultAsync(type => type.Id == id);
    }

    public Task<List<ProductType>> GetAllAsync()
    {
        return _context.ProductTypes.ToListAsync();
    }

    public void Add(ProductType type)
    {
        _context.ProductTypes.Add(type);
    }

    public void Update(ProductType type)
    {
        _context.ProductTypes.Update(type);
    }

    public void Remove(ProductType type)
    {
        _context.ProductTypes.Remove(type);
    }
}