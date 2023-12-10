using Microsoft.EntityFrameworkCore;
using RealEstateManager.Domain.Owners;
using RealEstateManager.Domain.Repository;

namespace RealEstateManager.Infrastructure.Repository
{
    public class OwnerRepository(RealEstateManagerDbContext realEstateManagerDbContext) : IOwnerRepository
    {
        private readonly RealEstateManagerDbContext _realEstateManagerDbContext = realEstateManagerDbContext;

        public async Task<IEnumerable<Owner>> GetAllAsync()
        {
            return await _realEstateManagerDbContext.Owner.ToListAsync();
        }

        public async Task<Owner?> GetByIdAsync(int idOwner)
        {
            return await _realEstateManagerDbContext.Owner.FirstOrDefaultAsync(t => t.IdOwner == idOwner);
        }

    }
}
