using Microsoft.EntityFrameworkCore;
using Tech_Store_Product_Service_Domain.Entities;

namespace Tech_Store_Product_Service_Infrastructure.DataContexts;

public class ProductsContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public DbSet<ProductType> ProductTypes { get; set; }

    public DbSet<ProductBrand> ProductBrands { get; set; }

    public DbSet<ProductGroup> ProductGroups { get; set; }

    public DbSet<Visuals> Visuals { get; set; }

    public DbSet<ProductSpecificationCategory> ProductCategories { get; set; }

    public DbSet<ProductSpecification> ProductSpecifications { get; set; }
    
    public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
    {
        
    }
}