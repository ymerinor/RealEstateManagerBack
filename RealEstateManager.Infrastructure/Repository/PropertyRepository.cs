using RealEstateManager.Domain.Propertys;
using RealEstateManager.Domain.Repository;

namespace RealEstateManager.Infrastructure.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        public Task<Property> CreateAsync(Property property)
        {
            throw new NotImplementedException();
        }
    }
}
