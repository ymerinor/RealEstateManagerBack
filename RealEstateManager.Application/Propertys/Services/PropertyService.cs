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

        public async Task<PropertyRequestDto> CreateAsync(PropertyRequestDto propertyRequestDto)
        {
            await OwnerExists(propertyRequestDto.IdOwner);
            var property = (Property)propertyRequestDto;
            await _propertyRepository.CreateAsync(property);
            return propertyRequestDto;
        }

        public async Task<IEnumerable<PropertyDto>> GetAllAsync()
        {
            var propertyInfomation = await _propertyRepository.GetAllAsync();
            var listPropertyDto = propertyInfomation.Select(s => (PropertyDto)s).ToList();
            return listPropertyDto;
        }
        public async Task<PropertyDto> ChangePreciAsync(int idProperty, ChangePriceProperty changePriceProperty)
        {
            var propertyUpdate = await _propertyRepository.GetByIdAsync(idProperty) ?? throw new NoFoundException($"no se encontro informacion relacionada con la propiedad id {idProperty} que intenta modificar");
            propertyUpdate.Price = changePriceProperty.Preci;
            return await _propertyRepository.UpdateAsync(propertyUpdate);
        }
        protected async Task<Owner> OwnerExists(int ownerId)
        {
            var ownerInfomation = await _ownerRepository.GetByIdAsync(ownerId);
            if (ownerInfomation is null)
            {
                throw new NoFoundException(nameof(Owner), ownerId);
            }
            else
            {
                return ownerInfomation;
            }
        }
    }
}
