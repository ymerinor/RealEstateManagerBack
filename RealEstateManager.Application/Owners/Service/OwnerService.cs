using RealEstateManager.Application.Owners.Interface;
using RealEstateManager.Domain.Owners;
using RealEstateManager.Domain.Repository;

namespace RealEstateManager.Application.Owners.Service
{
    /// <summary>
    /// Servicio que gestiona las operaciones relacionadas con la información de propietarios.
    /// </summary>
    public class OwnerService(IOwnerRepository ownerRepository) : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository = ownerRepository;

        /// <summary>
        /// Obtiene la información de todos los propietarios.
        /// </summary>
        /// <returns>Una colección que contiene la información de todos los propietarios.</returns>
        public async Task<IEnumerable<Owner>> GetAllAsync()
        {
            return await _ownerRepository.GetAllAsync();
        }

        /// <summary>
        /// Obtiene la información de un propietario basada en su identificador.
        /// </summary>
        /// <param name="idOwner">Identificador del propietario.</param>
        /// <returns>La información del propietario si se encuentra; de lo contrario, nulo.</returns>
        public async Task<Owner?> GetByIdAsync(int idOwner)
        {
            return await _ownerRepository.GetByIdAsync(idOwner);
        }

    }
}
