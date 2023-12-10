using RealEstateManager.Application.Common.Excepciones;
using RealEstateManager.Application.Propertys.Dto;
using RealEstateManager.Application.Propertys.Interfaces;
using RealEstateManager.Domain.Owners;
using RealEstateManager.Domain.Propertys;
using RealEstateManager.Domain.Repository;

namespace RealEstateManager.Application.Propertys.Services
{
    public class PropertyService(IPropertyRepository propertyRepository, IOwnerRepository ownerRepository) : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository = propertyRepository;
        private readonly IOwnerRepository _ownerRepository = ownerRepository;

        public async Task<Property> CreateAsync(PropertyRequestDto propertyRequestDto)
        {
            await OwnerExists(propertyRequestDto.IdOwner);
            var property = (Property)propertyRequestDto;
            property.CreateDate = DateTime.Now;
            return await _propertyRepository.CreateAsync(property);
        }

        public async Task<IEnumerable<PropertyDto>> GetAllAsync()
        {
            var propertyInfomation = await _propertyRepository.GetAllAsync();
            var listPropertyDto = propertyInfomation.Select(s => (PropertyDto)s).ToList();
            return listPropertyDto;
        }
        public async Task<PropertyDto> ChangePreciAsync(int idProperty, ChangePriceProperty changePriceProperty)
        {
            var propertyUpdate = await PropertyExists(idProperty);
            propertyUpdate.Price = changePriceProperty.Preci;
            return await _propertyRepository.UpdateAsync(propertyUpdate);
        }

        public async Task<Property> UpdateAsync(int idProperty, PropertyRequestDto propertyRequestDto)
        {
            _ = await PropertyExists(idProperty);
            await OwnerExists(propertyRequestDto.IdOwner);
            Property? propertyUpdate = propertyRequestDto;
            propertyUpdate.LastModified = DateTime.Now;
            return await _propertyRepository.UpdateAsync(propertyUpdate);
        }
        protected async Task<Owner> OwnerExists(int ownerId)
        {
            var ownerInfomation = await _ownerRepository.GetByIdAsync(ownerId);
            return ownerInfomation is null ? throw new NoFoundException(nameof(Owner), ownerId) : ownerInfomation;
        }

        protected async Task<Property> PropertyExists(int idProperty)
        {
            var properryInformation = await _propertyRepository.GetByIdAsync(idProperty);
            return properryInformation is null
                ? throw new NoFoundException($"no se encontro informacion relacionada con la propiedad id {idProperty} que intenta modificar")
                : properryInformation;
        }
    }
}
