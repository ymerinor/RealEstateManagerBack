using Microsoft.EntityFrameworkCore;
using RealEstateManager.Domain.Propertys;
using RealEstateManager.Domain.Repository;

namespace RealEstateManager.Infrastructure.Repository
{
    public class PropertyRepository(RealEstateManagerDbContext realEstateManagerDbContext) : IPropertyRepository
    {
        private readonly RealEstateManagerDbContext _realEstateManagerDbContext = realEstateManagerDbContext;

        public async Task<Property> CreateAsync(Property property)
        {
            await _realEstateManagerDbContext.Property.AddAsync(property);
            await Commit();
            return property;
        }

        public async Task<IEnumerable<Property>> GetAllAsync()
        {
            return await _realEstateManagerDbContext.Property.ToListAsync();
        }

        private async Task Commit()
        {
            await _realEstateManagerDbContext.SaveChangesAsync();
        }
    }
}
