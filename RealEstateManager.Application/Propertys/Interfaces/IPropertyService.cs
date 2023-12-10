using RealEstateManager.Application.Propertys.Dto;
using RealEstateManager.Domain.Propertys;

namespace RealEstateManager.Application.Propertys.Interfaces
{
    public interface IPropertyService
    {
        /// <summary>
        /// Cambia el precio de una propiedad identificada por su ID.
        /// </summary>
        /// <param name="idProperty">Identificador de la propiedad.</param>
        /// <param name="changePriceProperty">Información del nuevo precio.</param>
        Task<Property> ChangePreciAsync(int idProperty, ChangePriceProperty changePriceProperty);
        /// <summary>
        /// Crea una nueva propiedad utilizando la información proporcionada en el objeto PropertyRequestDto.
        /// </summary>
        /// <param name="propertyRequestDto">Información para crear la nueva propiedad.</param>
        /// <returns>La propiedad recién creada.</returns>
        Task<Property> CreateAsync(PropertyRequestDto propertyRequestDto);
        /// <summary>
        /// Obtiene la información de todas las propiedades en forma de una lista de PropertyDto.
        /// </summary>
        /// <returns>Lista de PropertyDto que representan todas las propiedades.</returns>
        Task<IEnumerable<PropertyDto>> GetAllAsync();
        /// <summary>
        /// Actualiza una propiedad existente identificada por su ID utilizando la información proporcionada en el objeto PropertyRequestDto.
        /// </summary>
        /// <param name="idProperty">Identificador de la propiedad a actualizar.</param>
        /// <param name="propertyRequestDto">Información actualizada de la propiedad.</param>
        /// <returns>La propiedad actualizada.</returns>
        Task<Property> UpdateAsync(int idPorperty, PropertyRequestDto propertyRequestDto);

        /// <summary>
        /// Obtiene una colección de propiedades aplicando filtros específicos.
        /// </summary>
        /// <param name="filtersQuery">Filtros de consulta para restringir los resultados.</param>
        /// <returns>Colección de objetos PropertyDto que cumplen con los criterios de filtro.</returns>
        Task<IEnumerable<PropertyDto>> GetWithFilters(FiltersQuery filtersQuery);
    }
}
