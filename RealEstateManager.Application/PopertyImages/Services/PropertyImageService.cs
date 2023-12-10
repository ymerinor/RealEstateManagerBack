using RealEstateManager.Application.Common.Excepciones;
using RealEstateManager.Application.PopertyImages.Dto;
using RealEstateManager.Application.PopertyImages.Interfaces;
using RealEstateManager.Domain.FilesManager;
using RealEstateManager.Domain.PropertyImages;
using RealEstateManager.Domain.Repository;

namespace RealEstateManager.Application.PopertyImages.Services
{
    public class PropertyImageService(IPropertyRepository propertyRepository,
        IPropertyImageRepository propertyImageRepository, IFilesManager filesManager) : IPropertyImageService
    {
        private readonly IPropertyRepository _propertyRepository = propertyRepository;

        private readonly IPropertyImageRepository _propertyImageRepository = propertyImageRepository;

        private readonly IFilesManager _filesManager = filesManager;
        public async Task<PropertyImage> AddImagePropertyAsync(PropertyImageDto propertyImageDto)
        {
            var existsProperty = await _propertyRepository.GetByIdAsync(propertyImageDto.IdProperty);
            if (existsProperty is null)
                throw new NoContentException($"no se encontro informacion relacionada con la propiedad id {propertyImageDto.IdProperty}");

            var pathfile = await _filesManager.SaveImageAsync(propertyImageDto.ImageFile);
            var propertyImage = new PropertyImage { FilePath = pathfile, IdProperty = 3, Enabled = true };

            return await _propertyImageRepository.CreateAsync(propertyImage);
        }
    }
}
