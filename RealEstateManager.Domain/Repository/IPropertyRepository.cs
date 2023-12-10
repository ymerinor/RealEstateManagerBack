using RealEstateManager.Domain.Propertys;

namespace RealEstateManager.Domain.Repository
{
    /// <summary>
    /// Interfaz que define las operaciones disponibles para acceder y gestionar propiedades inmobiliarias en el repositorio.
    /// </summary>
    public interface IPropertyRepository
    {
        /// <summary>
        /// Crea una nueva propiedad en el repositorio.
        /// </summary>
        /// <param name="property">La propiedad que se va a crear.</param>
        /// <returns>La propiedad recién creada.</returns>
        Task<Property> CreateAsync(Property property);
        /// <summary>
        /// Obtiene una propiedad del repositorio basada en su identificador.
        /// </summary>
        /// <param name="idProperty">Identificador de la propiedad.</param>
        /// <returns>La propiedad encontrada o nulo si no se encuentra.</returns>
        Task<Property?> GetByIdAsync(int idProperty);
        /// <summary>
        /// Obtiene todas las propiedades almacenadas en el repositorio.
        /// </summary>
        /// <returns>Una colección de todas las propiedades.</returns>
        Task<IEnumerable<Property>> GetAllAsync();
        /// <summary>
        /// Actualiza una propiedad existente en el repositorio.
        /// </summary>
        /// <param name="property">La propiedad que se va a actualizar.</param>
        /// <returns>La propiedad actualizada.</returns>
        Task<Property> UpdateAsync(Property property);
    }
}
