using RealEstateManager.Application.Propertys.Dto;
using RealEstateManager.Application.Propertys.Interfaces;
using RealEstateManager.Domain.Propertys;
using RealEstateManager.Domain.Repository;

namespace RealEstateManager.Application.Propertys.Services
{
    public class PropertyService(IPropertyRepository propertyRepository) : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository = propertyRepository;

        public async Task<PropertyRequestDto> CreateAsync(PropertyRequestDto propertyRequestDto)
        {
            var property = (Property)propertyRequestDto;
            await _propertyRepository.CreateAsync(property);
            return propertyRequestDto;
        }
    }
}
