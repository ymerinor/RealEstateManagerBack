using RealEstateManager.Domain.Owners;

namespace RealEstateManager.Application.Owners.Interface
{
    /// <summary>
    /// Interfaz que define las operaciones disponibles para acceder a la información de propietarios.
    /// </summary>
    public interface IOwnerService
    {
        /// <summary>
        /// Obtiene la información de un propietario basada en su identificador.
        /// </summary>
        /// <param name="idOwner">Identificador del propietario.</param>
        /// <returns>La información del propietario si se encuentra; de lo contrario, nulo.</returns>
        Task<Owner?> GetByIdAsync(int idOwner);

        /// <summary>
        /// Obtiene la información de todos los propietarios.
        /// </summary>
        /// <returns>Una colección que contiene la información de todos los propietarios.</returns>
        Task<IEnumerable<Owner>> GetAllAsync();
    }

}
