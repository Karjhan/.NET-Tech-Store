using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Tech_Store_Product_Service_Domain.Abstractions;
using Tech_Store_Product_Service_Domain.Entities;
using Tech_Store_Product_Service_Domain.Primitives;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Tech_Store_Product_Service_Infrastructure.DataContexts;

public class ApplicationContext : DbContext, IUnitOfWork
{
    public DbSet<Product> Products { get; set; }

    public DbSet<ProductType> ProductTypes { get; set; }

    public DbSet<ProductBrand> ProductBrands { get; set; }

    public DbSet<ProductGroup> ProductGroups { get; set; }

    public DbSet<Visuals> Visuals { get; set; }

    public DbSet<ProductSpecificationCategory> ProductSpecificationCategoriesCategories { get; set; }

    public DbSet<ProductSpecification> ProductSpecifications { get; set; }

    public DbSet<VisualsPictureSource> PictureSources { get; set; }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}