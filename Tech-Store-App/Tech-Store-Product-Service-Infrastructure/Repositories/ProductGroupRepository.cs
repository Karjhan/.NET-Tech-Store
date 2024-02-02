using Microsoft.EntityFrameworkCore;
using Tech_Store_Product_Service_Domain.Abstractions;
using Tech_Store_Product_Service_Domain.Entities;
using Tech_Store_Product_Service_Infrastructure.DataContexts;

namespace Tech_Store_Product_Service_Infrastructure.Repositories;

public class ProductGroupRepository : IProductGroupRepository
{
    private readonly ApplicationContext _context;

    public ProductGroupRepository(ApplicationContext context)
    {
        _context = context;
    }

    public Task<ProductGroup?> GetByIdAsync(Guid id)
    {
        return _context.ProductGroups.SingleOrDefaultAsync(group => group.Id == id);
    }

    public Task<List<ProductGroup>> GetAllAsync()
    {
        return _context.ProductGroups.ToListAsync();
    }

    public void Add(ProductGroup group)
    {
        _context.ProductGroups.Add(group);
    }

    public void Update(ProductGroup group)
    {
        _context.ProductGroups.Update(group);
    }

    public void Remove(ProductGroup group)
    {
        _context.ProductGroups.Remove(group);
    }
}