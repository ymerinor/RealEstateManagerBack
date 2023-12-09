using RealEstateManager.Application.Owners.Interface;
using RealEstateManager.Domain.Owners;
using RealEstateManager.Domain.Repository;

namespace RealEstateManager.Application.Owners
{
    public class OwnerService(IOwnerRepository ownerRepository) : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository = ownerRepository;

        public async Task<Owner> GetByIdAsync(int idOwner)
        {
            return await _ownerRepository.GetByIdAsync(idOwner);
        }
    }
}
