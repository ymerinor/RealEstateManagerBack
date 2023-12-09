using RealEstateManager.Application.Propertys.Dto;

namespace RealEstateManager.Application.Propertys.Interfaces
{
    public interface IPropertyService
    {
        Task<PropertyRequestDto> CreateAsync(PropertyRequestDto propertyRequestDto);
        Task<IEnumerable<PropertyDto>> GetAllAsync();
    }
}
