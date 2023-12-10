using RealEstateManager.Domain.Owners;

namespace RealEstateManager.Domain.Repository
{
    /// <summary>
    /// Interfaz que define las operaciones disponibles para acceder y gestionar la información de propietarios en el repositorio.
    /// </summary>
    public interface IOwnerRepository
    {
        /// <summary>
        /// Obtiene la información de todos los propietarios almacenados en el repositorio.
        /// </summary>
        /// <returns>Una colección que contiene la información de todos los propietarios.</returns>
        Task<IEnumerable<Owner>> GetAllAsync();

        /// <summary>
        /// Obtiene la información de un propietario basada en su identificador.
        /// </summary>
        /// <param name="idOwner">Identificador del propietario.</param>
        /// <returns>La información del propietario si se encuentra; de lo contrario, nulo.</returns>
        Task<Owner?> GetByIdAsync(int idOwner);
    }

}
