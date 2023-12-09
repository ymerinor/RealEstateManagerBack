using RealEstateManager.Domain.Owners;

namespace RealEstateManager.Domain.Repository
{
    public interface IOwnerRepository
    {
        Task<Owner> GetByIdAsync(int v);
    }
}
