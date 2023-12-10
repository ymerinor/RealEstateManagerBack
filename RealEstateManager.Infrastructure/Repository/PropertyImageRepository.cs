using RealEstateManager.Domain.PropertyImages;
using RealEstateManager.Domain.Repository;

namespace RealEstateManager.Infrastructure.Repository
{
    public class PropertyImageRepository(RealEstateManagerDbContext realEstateManagerDbContext) : IPropertyImageRepository
    {
        private readonly RealEstateManagerDbContext _realEstateManagerDbContext = realEstateManagerDbContext;

        public async Task<PropertyImage> CreateAsync(PropertyImage propertyImage)
        {
            await _realEstateManagerDbContext.PropertyImage.AddAsync(propertyImage);
            await _realEstateManagerDbContext.SaveChangesAsync();
            return propertyImage;
        }
    }
}
