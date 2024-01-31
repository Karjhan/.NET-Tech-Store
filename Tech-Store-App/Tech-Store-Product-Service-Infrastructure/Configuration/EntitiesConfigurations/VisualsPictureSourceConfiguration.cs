using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tech_Store_Product_Service_Domain.Entities;

namespace Tech_Store_Product_Service_Infrastructure.Configuration.EntitiesConfigurations;

public class VisualsPictureSourceConfiguration : IEntityTypeConfiguration<VisualsPictureSource>
{
    public void Configure(EntityTypeBuilder<VisualsPictureSource> builder)
    {
        builder.ToTable("VisualsPictureSources");
        
        builder.Property(visualsPictureSource => visualsPictureSource.Id).HasColumnName("VisualsId");

        builder.HasKey(visualsPictureSource => visualsPictureSource.PictureURL);
    }
}