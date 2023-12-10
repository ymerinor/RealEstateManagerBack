using RealEstateManager.Application.Common.Excepciones;
using RealEstateManager.Application.Propertys.Dto;
using RealEstateManager.Application.Propertys.Interfaces;
using RealEstateManager.Domain.Owners;
using RealEstateManager.Domain.Propertys;
using RealEstateManager.Domain.Repository;

namespace RealEstateManager.Application.Propertys.Services
{
    /// <summary>
    /// Servicio que gestiona las operaciones relacionadas con propiedades inmobiliarias.
    /// </summary>
    public class PropertyService(IPropertyRepository propertyRepository, IOwnerRepository ownerRepository) : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository = propertyRepository;
        private readonly IOwnerRepository _ownerRepository = ownerRepository;

        /// <inheritdoc/>
        public async Task<Property> CreateAsync(PropertyRequestDto propertyRequestDto)
        {
            await OwnerExists(propertyRequestDto.IdOwner);
            var property = (Property)propertyRequestDto;
            property.CreateDate = DateTime.Now;
            return await _propertyRepository.CreateAsync(property);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PropertyDto>> GetAllAsync()
        {
            var propertyInfomation = await _propertyRepository.GetAllAsync();
            var listPropertyDto = propertyInfomation.Select(s => (PropertyDto)s).ToList();
            return listPropertyDto;
        }

        /// <inheritdoc/>
        public async Task<Property> ChangePreciAsync(int idProperty, ChangePriceProperty changePriceProperty)
        {
            var propertyaChangePreci = await PropertyExists(idProperty);
            propertyaChangePreci.Price = changePriceProperty.Preci;
            propertyaChangePreci.LastModified = DateTime.Now;
            return await _propertyRepository.UpdateAsync(propertyaChangePreci);
        }

        /// <inheritdoc/>
        public async Task<Property> UpdateAsync(int idProperty, PropertyRequestDto propertyRequestDto)
        {
            var propertyUpdate = await PropertyExists(idProperty);
            await OwnerExists(propertyRequestDto.IdOwner);
            PropertyRequestDto.PropertyDtoToProperty(propertyRequestDto, propertyUpdate);
            propertyUpdate.LastModified = DateTime.Now;
            return await _propertyRepository.UpdateAsync(propertyUpdate);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PropertyDto>> GetWithFilters(FiltersQuery filtersQuery)
        {
            var propertyInfomation = await _propertyRepository.GetAllAsync();
            var listPropertyDto = propertyInfomation
             .Where(t => (filtersQuery.IdProperty == null || t.IdProperty == filtersQuery.IdProperty)
                         && (filtersQuery.IdOwner == null || t.IdOwner == filtersQuery.IdOwner)
                         && (filtersQuery.IdPropertyType == null || t.IdPropertyType == filtersQuery.IdPropertyType)
                         && (filtersQuery.CodeInternal == null || t.CodeInternal == filtersQuery.CodeInternal))
             .Select(s => (PropertyDto)s)
             .ToList();
            return listPropertyDto;
        }
        /// <summary>
        /// Verifica si existe un propietario dado su identificador.
        /// </summary>
        /// <param name="ownerId">Identificador del propietario.</param>
        /// <returns>El propietario si existe; de lo contrario, se lanza una excepción NotFoundException.</returns>
        /// <exception cref="NoContentException">En caso de no existir el owner</exception>
        protected async Task<Owner> OwnerExists(int ownerId)
        {
            var ownerInfomation = await _ownerRepository.GetByIdAsync(ownerId);
            return ownerInfomation is null ? throw new NoContentException(nameof(Owner), ownerId) : ownerInfomation;
        }

        /// <summary>
        /// Verifica si existe una propiedad dada su identificador.
        /// </summary>
        /// <param name="idProperty">Identificador de la propiedad.</param>
        /// <returns>La propiedad si existe; de lo contrario, se lanza una excepción NotFoundException.</returns>
        /// <exception cref="NoContentException">En caso de no existir el la propiedad</exception>
        protected async Task<Property> PropertyExists(int idProperty)
        {
            var properryInformation = await _propertyRepository.GetByIdAsync(idProperty);
            return properryInformation is null
                ? throw new NoContentException($"no se encontro informacion relacionada con la propiedad id {idProperty} que intenta modificar")
                : properryInformation;
        }
    }
}
