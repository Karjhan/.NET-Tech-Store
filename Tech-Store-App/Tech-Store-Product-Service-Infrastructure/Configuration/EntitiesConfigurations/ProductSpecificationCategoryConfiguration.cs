using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tech_Store_Product_Service_Domain.Entities;

namespace Tech_Store_Product_Service_Infrastructure.Configuration.EntitiesConfigurations;

public class ProductSpecificationCategoryConfiguration : IEntityTypeConfiguration<ProductSpecificationCategory>
{
    public void Configure(EntityTypeBuilder<ProductSpecificationCategory> builder)
    {
        builder.ToTable("ProductSpecificationCategories");
        
        builder.HasIndex(productSpecificationCategory => new { productSpecificationCategory.Id, productSpecificationCategory.Name }).IsUnique();
        
        builder.HasKey(productSpecificationCategory => new { productSpecificationCategory.Id, productSpecificationCategory.Name });
        
        builder.HasOne(productSpecificationCategory => productSpecificationCategory.ProductType).WithMany().HasForeignKey(productSpecificationCategory => productSpecificationCategory.Id);

        builder.Property(productSpecificationCategory => productSpecificationCategory.Id).HasColumnName("ProductTypeId");
    }
}