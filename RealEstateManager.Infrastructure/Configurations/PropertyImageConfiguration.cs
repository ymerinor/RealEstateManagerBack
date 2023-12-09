using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateManager.Domain.PropertyImages;
using System.Diagnostics.CodeAnalysis;

namespace RealEstateManager.Infrastructure.Configurations
{
    [ExcludeFromCodeCoverage]
    public class PropertyImageConfiguration : IEntityTypeConfiguration<PropertyImage>
    {
        [ExcludeFromCodeCoverage]
        public void Configure(EntityTypeBuilder<PropertyImage> builder)
        {
            builder.ToTable("PropertyImage");

            builder.HasKey("IdPropertyImage");

            builder.Property(e => e.FilePath)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.HasOne(e => e.Property)
            .WithMany(e => e.PropertyImages)
            .HasForeignKey(e => e.IdProperty);
        }

    }
}
