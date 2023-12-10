using RealEstateManager.Application.Propertys.Dto;
using RealEstateManager.Domain.Propertys;

namespace RealEstateManager.Application.Propertys.Interfaces
{
    public interface IPropertyService
    {
        Task<PropertyDto> ChangePreciAsync(int idProperty, ChangePriceProperty changePriceProperty);
        Task<Property> CreateAsync(PropertyRequestDto propertyRequestDto);
        Task<IEnumerable<PropertyDto>> GetAllAsync();
        Task<Property> UpdateAsync(int idPorperty, PropertyRequestDto propertyRequestDto);
    }
}
