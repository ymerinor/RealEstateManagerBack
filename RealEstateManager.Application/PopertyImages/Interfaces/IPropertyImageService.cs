using RealEstateManager.Application.PopertyImages.Dto;
using RealEstateManager.Domain.PropertyImages;

namespace RealEstateManager.Application.PopertyImages.Interfaces
{
    public interface IPropertyImageService
    {
        Task<PropertyImage> AddImagePropertyAsync(PropertyImageDto propertyImageDto);
    }
}
