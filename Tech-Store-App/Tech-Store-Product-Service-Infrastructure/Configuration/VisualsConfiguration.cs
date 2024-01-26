using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tech_Store_Product_Service_Domain.Entities;

namespace Tech_Store_Product_Service_Infrastructure.Configuration;

public class VisualsConfiguration : IEntityTypeConfiguration<Visuals>
{
    public void Configure(EntityTypeBuilder<Visuals> builder)
    {
        builder.ToTable("Visuals");
    }
}