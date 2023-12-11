using RealEstateManager.Application.Common.Excepciones;
using RealEstateManager.Application.PopertyImages.Dto;
using RealEstateManager.Application.PopertyImages.Interfaces;
using RealEstateManager.Domain.FilesManager;
using RealEstateManager.Domain.PropertyImages;
using RealEstateManager.Domain.Repository;

namespace RealEstateManager.Application.PopertyImages.Services
{
    /// <summary>
    /// Servicio encargado de gestionar las imágenes asociadas a propiedades.
    /// </summary>
    /// <remarks>
    /// Constructor de la clase <see cref="PropertyImageService"/>.
    /// </remarks>
    /// <param name="propertyRepository">Repositorio de propiedades.</param>
    /// <param name="propertyImageRepository">Repositorio de imágenes de propiedades.</param>
    /// <param name="filesManager">Gestor de archivos.</param>
    public class PropertyImageService(
        IPropertyRepository propertyRepository,
        IPropertyImageRepository propertyImageRepository,
        IFilesManager filesManager) : IPropertyImageService
    {
        private readonly IPropertyRepository _propertyRepository = propertyRepository;
        private readonly IPropertyImageRepository _propertyImageRepository = propertyImageRepository;
        private readonly IFilesManager _filesManager = filesManager;

        /// <inheritdoc/>
        public async Task<PropertyImageOut> AddImagePropertyAsync(PropertyImageDto propertyImageDto)
        {
            // Verificar si la propiedad existe
            var existsProperty = await _propertyRepository.GetByIdAsync(propertyImageDto.IdProperty);
            if (existsProperty is null)
                throw new NoContentException($"No se encontró información relacionada con la propiedad ID {propertyImageDto.IdProperty}");

            var pathfile = await _filesManager.SaveImageAsync(propertyImageDto.ImageFile);
            var propertyImage = new PropertyImage { FilePath = pathfile, IdProperty = existsProperty.IdProperty, Enabled = true };
            var propertyImageUpload = await _propertyImageRepository.CreateAsync(propertyImage);
            return (PropertyImageOut)propertyImageUpload;
        }
    }

}
