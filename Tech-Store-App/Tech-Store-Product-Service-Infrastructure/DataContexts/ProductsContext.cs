using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Tech_Store_Product_Service_Domain.Abstractions;
using Tech_Store_Product_Service_Domain.Entities;

namespace Tech_Store_Product_Service_Infrastructure.DataContexts;

public class ProductsContext : DbContext, IUnitOfWork
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
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}