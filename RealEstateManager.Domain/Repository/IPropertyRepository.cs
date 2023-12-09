using RealEstateManager.Domain.Propertys;

namespace RealEstateManager.Domain.Repository
{
    public interface IPropertyRepository
    {
        Task<Property> CreateAsync(Property property);
    }
}
