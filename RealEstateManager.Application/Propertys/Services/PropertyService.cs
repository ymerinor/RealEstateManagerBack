﻿using RealEstateManager.Application.Common.Excepciones;
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
