using RealEstateManager.Application.PopertyImages.Dto;
using RealEstateManager.Domain.PropertyImages;

namespace RealEstateManager.Application.PopertyImages.Interfaces
{
    public interface IPropertyImageService
    {
        /// <summary>
        /// Agrega una imagen a una propiedad existente.
        /// </summary>
        /// <param name="propertyImageDto">DTO de la imagen de la propiedad.</param>
        /// <returns>La entidad <see cref="PropertyImage"/> creada.</returns>
        Task<PropertyImageOut> AddImagePropertyAsync(PropertyImageDto ImageFile);
    }
}
