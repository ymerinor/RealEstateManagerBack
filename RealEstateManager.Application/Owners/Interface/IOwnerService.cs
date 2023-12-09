using RealEstateManager.Domain.Owners;

namespace RealEstateManager.Application.Owners.Interface
{
    public interface IOwnerService
    {
        Task<Owner> GetByIdAsync(int idOwner);
        Task<IEnumerable<Owner>> GetAllAsync();
    }
}
