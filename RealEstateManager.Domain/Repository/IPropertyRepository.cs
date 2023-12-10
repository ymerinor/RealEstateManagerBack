using RealEstateManager.Domain.Propertys;

namespace RealEstateManager.Domain.Repository
{
    public interface IPropertyRepository
    {
        Task<Property> CreateAsync(Property property);
        Task<Property?> GetByIdAsync(int idProperty);
        Task<IEnumerable<Property>> GetAllAsync();
        Task<Property> UpdateAsync(Property property);
    }
}
