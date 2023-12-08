using RealEstateManager.Application.Property.Dto;

namespace RealEstateManager.Application.Property.Interfaces
{
    public interface IPropertyServices
    {
        Task<PropertyRequestDto> CreateAsync(PropertyRequestDto propertyRequestDto);
    }
}
