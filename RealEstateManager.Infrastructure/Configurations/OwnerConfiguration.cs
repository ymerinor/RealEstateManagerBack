using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateManager.Domain.Owners;
using System.Diagnostics.CodeAnalysis;

namespace RealEstateManager.Infrastructure.Configurations
{
    [ExcludeFromCodeCoverage]
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        [ExcludeFromCodeCoverage]
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owner");
            builder.HasKey("IdOwner");
        }

    }
}
