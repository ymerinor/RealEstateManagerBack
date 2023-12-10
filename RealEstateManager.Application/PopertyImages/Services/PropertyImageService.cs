using RealEstateManager.Application.PopertyImages.Dto;
using RealEstateManager.Application.PopertyImages.Interfaces;
using RealEstateManager.Domain.PropertyImages;

namespace RealEstateManager.Application.PopertyImages.Services
{
    public class PropertyImageService : IPropertyImageService
    {
        public Task<PropertyImage> AddImagePropertyAsync(PropertyImageDto propertyImageDto)
        {
            throw new NotImplementedException();
        }
    }
}
