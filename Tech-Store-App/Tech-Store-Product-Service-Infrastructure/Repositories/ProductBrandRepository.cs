using Microsoft.EntityFrameworkCore;
using Tech_Store_Product_Service_Domain.Abstractions;
using Tech_Store_Product_Service_Domain.Entities;
using Tech_Store_Product_Service_Infrastructure.DataContexts;

namespace Tech_Store_Product_Service_Infrastructure.Repositories;

public sealed class ProductBrandRepository : IProductBrandRepository
{
    private readonly ApplicationContext _context;

    public ProductBrandRepository(ApplicationContext context)
    {
        _context = context;
    }

    public Task<ProductBrand?> GetByIdAsync(Guid id)
    {
        return _context.ProductBrands.SingleOrDefaultAsync(brand => brand.Id == id);
    }

    public Task<List<ProductBrand>> GetAllAsync()
    {
        return _context.ProductBrands.ToListAsync();
    }

    public void Add(ProductBrand brand)
    {
        _context.ProductBrands.Add(brand);
    }

    public void Update(ProductBrand brand)
    {
        _context.ProductBrands.Update(brand);
    }

    public void Remove(ProductBrand brand)
    {
        _context.ProductBrands.Remove(brand);
    }
}