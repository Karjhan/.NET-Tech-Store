using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tech_Store_Product_Service_Domain.Entities;

namespace Tech_Store_Product_Service_Infrastructure.Configuration.EntitiesConfigurations;

public class ProductGroupConfiguration : IEntityTypeConfiguration<ProductGroup>
{
    public void Configure(EntityTypeBuilder<ProductGroup> builder)
    {
        builder.ToTable("ProductGroups");
        
        builder.HasKey(productGroup => productGroup.Id);
        
        builder.HasMany(productGroup => productGroup.ProductTypes).WithOne().OnDelete(DeleteBehavior.Cascade).HasForeignKey(productType => productType.ProductGroupId).IsRequired();
    }
}