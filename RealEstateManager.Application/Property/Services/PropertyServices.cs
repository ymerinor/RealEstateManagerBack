using RealEstateManager.Application.Property.Dto;
using RealEstateManager.Application.Property.Interfaces;

namespace RealEstateManager.Application.Property.Services
{
    public class PropertyServices : IPropertyServices
    {
        public Task<PropertyRequestDto> CreateAsync(PropertyRequestDto propertyRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
