using RealEstateManager.Application.PopertyImages.Dto;
using RealEstateManager.Application.PopertyImages.Interfaces;
using RealEstateManager.Domain.PropertyImages;
using RealEstateManager.Domain.Repository;

namespace RealEstateManager.Application.PopertyImages.Services
{
    public class PropertyImageService(IPropertyRepository propertyRepository, IPropertyImageRepository propertyImageRepository) : IPropertyImageService
    {
        private readonly IPropertyRepository _propertyRepository = propertyRepository;

        private readonly IPropertyImageRepository _propertyImageRepository = propertyImageRepository;
        public async Task<PropertyImage> AddImagePropertyAsync(PropertyImageDto propertyImageDto)
        {
            var propertyImage = new PropertyImage { FilePath = "" };
            return await _propertyImageRepository.CreateAsync(propertyImage);
        }
    }
}
