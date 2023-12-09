using RealEstateManager.Domain.Owners;

namespace RealEstateManager.Domain.Repository
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetAllAsync();
        Task<Owner> GetByIdAsync(int idOwner);
    }
}
