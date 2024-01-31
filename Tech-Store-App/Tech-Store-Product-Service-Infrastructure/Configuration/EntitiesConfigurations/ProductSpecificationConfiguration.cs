using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tech_Store_Product_Service_Domain.Entities;

namespace Tech_Store_Product_Service_Infrastructure.Configuration.EntitiesConfigurations;

public class ProductSpecificationConfiguration : IEntityTypeConfiguration<ProductSpecification>
{
    public void Configure(EntityTypeBuilder<ProductSpecification> builder)
    {
        builder.ToTable("ProductSpecifications");
        
        builder.HasOne(productSpecification => productSpecification.Category).WithMany().HasForeignKey(productSpecification =>  new { productSpecification.ProductTypeId, productSpecification.CategoryName });

        builder.HasIndex(productSpecification => new { productSpecification.Id, productSpecification.Name }).IsUnique();
        
        builder.HasKey(productSpecification => new { productSpecification.Id, productSpecification.Name });

        builder.Property(productSpecification => productSpecification.Id).HasColumnName("ProductId");
    }
}