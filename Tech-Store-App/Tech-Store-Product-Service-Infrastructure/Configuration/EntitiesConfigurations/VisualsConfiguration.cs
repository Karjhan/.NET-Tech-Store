using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tech_Store_Product_Service_Domain.Entities;

namespace Tech_Store_Product_Service_Infrastructure.Configuration.EntitiesConfigurations;

public class VisualsConfiguration : IEntityTypeConfiguration<Visuals>
{
    public void Configure(EntityTypeBuilder<Visuals> builder)
    {
        builder.ToTable("Visuals");
        
        builder.HasKey(visuals => visuals.Id);
                
        builder.Property(visuals => visuals.MainPictureURL).IsRequired();

        builder.HasMany(visuals => visuals.PictureSources).WithOne().OnDelete(DeleteBehavior.Cascade).HasForeignKey(visualsPictureSource => visualsPictureSource.Id).IsRequired();
    }
}