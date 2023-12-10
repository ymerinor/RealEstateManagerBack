using RealEstateManager.Domain.PropertyImages;

namespace RealEstateManager.Domain.Repository
{
    public interface IPropertyImageRepository
    {
        Task<PropertyImage> CreateAsync(PropertyImage propertyImage);
    }
}
