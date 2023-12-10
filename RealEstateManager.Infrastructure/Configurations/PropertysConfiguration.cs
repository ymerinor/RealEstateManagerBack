using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateManager.Domain.Propertys;
using System.Diagnostics.CodeAnalysis;

namespace RealEstateManager.Infrastructure.Configurations
{
    [ExcludeFromCodeCoverage]
    public class PropertysConfiguration : IEntityTypeConfiguration<Property>
    {
        [ExcludeFromCodeCoverage]
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Property");
            builder.HasKey("IdProperty");

            builder.HasOne(a => a.Owner).WithMany().HasForeignKey(b => b.IdOwner);

            builder.HasOne(a => a.PropertyType).WithMany().HasForeignKey(b => b.IdPropertyType);
        }

    }
}
