using Microsoft.EntityFrameworkCore;
using RealEstateManager.Domain.Owners;
using RealEstateManager.Domain.Repository;

namespace RealEstateManager.Infrastructure.Repository
{
    /// <summary>
    /// Repositorio que implementa operaciones para acceder y gestionar la información de propietarios en el contexto de la base de datos.
    /// </summary>
    public class OwnerRepository(RealEstateManagerDbContext realEstateManagerDbContext) : IOwnerRepository
    {
        private readonly RealEstateManagerDbContext _realEstateManagerDbContext = realEstateManagerDbContext;

        /// <summary>
        /// Obtiene la información de todos los propietarios almacenados en el repositorio.
        /// </summary>
        /// <returns>Una colección que contiene la información de todos los propietarios.</returns>
        public async Task<IEnumerable<Owner>> GetAllAsync()
        {
            return await _realEstateManagerDbContext.Owner.ToListAsync();
        }

        /// <summary>
        /// Obtiene la información de un propietario basada en su identificador.
        /// </summary>
        /// <param name="idOwner">Identificador del propietario.</param>
        /// <returns>La información del propietario si se encuentra; de lo contrario, nulo.</returns>
        public async Task<Owner?> GetByIdAsync(int idOwner)
        {
            return await _realEstateManagerDbContext.Owner.FirstOrDefaultAsync(t => t.IdOwner == idOwner);
        }
    }
}
