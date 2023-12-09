using RealEstateManager.Domain.Propertys;
using RealEstateManager.Domain.Repository;

namespace RealEstateManager.Infrastructure.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly RealEstateManagerDbContext _realEstateManagerDbContext;
        public PropertyRepository(RealEstateManagerDbContext realEstateManagerDbContext)
        {
            _realEstateManagerDbContext = realEstateManagerDbContext;
        }
        public async Task<Property> CreateAsync(Property property)
        {
            await _realEstateManagerDbContext.Property.AddAsync(property);
            await Commit();
            return property;
        }

        private async Task Commit()
        {
            await _realEstateManagerDbContext.SaveChangesAsync();
        }
    }
}
