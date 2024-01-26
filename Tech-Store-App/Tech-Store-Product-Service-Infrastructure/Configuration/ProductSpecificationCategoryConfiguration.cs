using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tech_Store_Product_Service_Domain.Entities;

namespace Tech_Store_Product_Service_Infrastructure.Configuration;

public class ProductSpecificationCategoryConfiguration : IEntityTypeConfiguration<ProductSpecificationCategory>
{
    public void Configure(EntityTypeBuilder<ProductSpecificationCategory> builder)
    {
        builder.ToTable("ProductSpecificationCategories");
    }
}