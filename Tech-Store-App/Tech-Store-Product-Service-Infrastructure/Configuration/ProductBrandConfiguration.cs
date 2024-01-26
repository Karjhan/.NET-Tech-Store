using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tech_Store_Product_Service_Infrastructure.Configuration;

public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrandConfiguration>
{
    public void Configure(EntityTypeBuilder<ProductBrandConfiguration> builder)
    {
        builder.ToTable("Brands");
    }
}