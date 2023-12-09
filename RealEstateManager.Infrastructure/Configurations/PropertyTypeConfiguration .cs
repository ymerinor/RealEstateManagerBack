using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateManager.Domain.PropertyTypes;
using System.Diagnostics.CodeAnalysis;

namespace RealEstateManager.Infrastructure.Configurations
{
    [ExcludeFromCodeCoverage]
    public class PropertyTypeConfiguration : IEntityTypeConfiguration<PropertyType>
    {
        [ExcludeFromCodeCoverage]
        public void Configure(EntityTypeBuilder<PropertyType> builder)
        {
            builder.ToTable("PropertyType");

            builder.HasKey("IdPropertyType");
        }

    }
}
