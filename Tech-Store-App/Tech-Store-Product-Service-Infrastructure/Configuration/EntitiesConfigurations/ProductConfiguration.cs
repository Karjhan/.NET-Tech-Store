using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tech_Store_Product_Service_Domain.Entities;

namespace Tech_Store_Product_Service_Infrastructure.Configuration.EntitiesConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(product => product.Id);
        
        builder.HasOne(product => product.ProductBrand).WithMany().HasForeignKey(product => product.ProductBrandId);
        
        builder.HasOne(product => product.ProductType).WithMany().HasForeignKey(product => product.ProductTypeId);
        
        builder.HasOne(product => product.ProductGroup).WithMany().HasForeignKey(product => product.ProductGroupId);

        builder.HasMany(product => product.Specifications).WithOne().OnDelete(DeleteBehavior.Cascade).HasForeignKey(productSpecification => productSpecification.Id).IsRequired();
    }
}