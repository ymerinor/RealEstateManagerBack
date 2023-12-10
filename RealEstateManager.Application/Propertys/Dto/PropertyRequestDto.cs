using RealEstateManager.Application.Common;
using RealEstateManager.Domain.Propertys;

namespace RealEstateManager.Application.Propertys.Dto
{
    /// <summary>
    /// Objeto request para la creacion de una Propeidad
    /// </summary>
    public class PropertyRequestDto
    {

        /// <summary>
        /// Obtiene o establece el nombre de la propiedad. Puede ser nulo.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Obtiene o establece los detalles de la propiedad.No Puede ser nulo.
        /// </summary>
        public string Details { get; set; } = null!;

        /// <summary>
        /// Obtiene o establece el código interno de la propiedad.No Puede ser nulo.
        /// </summary>
        public string CodeInternal { get; set; } = null!;

        /// <summary>
        /// Obtiene o establece la ciudad de la propiedad.
        /// </summary>
        public string City { get; set; } = null!;

        /// <summary>
        /// Obtiene o establece el país de la propiedad.
        /// </summary>
        public string Country { get; set; } = null!;

        /// <summary>
        /// Obtiene o establece la dirección de la propiedad.
        /// </summary>
        public string Address { get; set; } = null!;

        /// <summary>
        /// Obtiene o establece el número de habitaciones de la propiedad.
        /// </summary>
        public int Bedrooms { get; set; }

        /// <summary>
        /// Obtiene o establece el número de baños de la propiedad.
        /// </summary>
        public int Bathrooms { get; set; }

        /// <summary>
        /// Obtiene o establece el año de construcción de la propiedad.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Obtiene o establece el precio de la propiedad.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del propietario mediante la clave externa.
        /// </summary>
        public int IdOwner { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del tipo de propiedad.
        /// </summary>
        public int PropertyType { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de la propiedad.
        /// </summary>
        public PropertysStatusEnum Status { get; set; }



        // <summary>
        /// Convierte de forma implícita una instancia de PropertyRequestDto a Property.
        /// </summary>
        /// <param name="requestDto">Instancia de PropertyRequestDto a convertir.</param>
        /// <returns>Instancia de Property resultante de la conversión.</returns>
        public static implicit operator Property(PropertyRequestDto requestDto)
        {
            return new Property
            {
                Name = requestDto.Name,
                Details = requestDto.Details,
                CodeInternal = requestDto.CodeInternal,
                City = requestDto.City,
                Country = requestDto.Country,
                Price = requestDto.Price,
                Address = requestDto.Address,
                Bedrooms = requestDto.Bedrooms,
                Bathrooms = requestDto.Bathrooms,
                Year = requestDto.Year,
                IdOwner = requestDto.IdOwner,
                IdPropertyType = requestDto.PropertyType,
                Status = requestDto.Status.ToString(), // Convertir el enum a string
            };
        }
        /// <summary>
        /// Convierte un objeto PropertyRequestDto a un objeto Property, aplicando las actualizaciones correspondientes.
        /// </summary>
        /// <param name="requestDto">Objeto PropertyRequestDto con la información de actualización.</param>
        /// <param name="property">Objeto Property que se actualizará con la información proporcionada en el PropertyRequestDto.</param>
        /// <returns>El objeto Property actualizado.</returns>
        public static Property PropertyDtoToProperty(PropertyRequestDto requestDto, Property property)
        {
            property.Name = requestDto.Name;
            property.Details = requestDto.Details;
            property.CodeInternal = requestDto.CodeInternal;
            property.City = requestDto.City;
            property.Country = requestDto.Country;
            property.Price = requestDto.Price;
            property.Address = requestDto.Address;
            property.Bedrooms = requestDto.Bedrooms;
            property.Bathrooms = requestDto.Bathrooms;
            property.Year = requestDto.Year;
            property.IdOwner = requestDto.IdOwner;
            property.IdPropertyType = requestDto.PropertyType;
            property.Status = requestDto.Status.ToString(); // Convertir el enum a string
            return property;
        }
    }
}
