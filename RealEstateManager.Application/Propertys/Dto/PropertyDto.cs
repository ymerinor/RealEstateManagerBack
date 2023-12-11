using RealEstateManager.Domain.Propertys;

namespace RealEstateManager.Application.Propertys.Dto
{
    public class PropertyDto
    {

        /// <summary>
        /// Obtiene o establece el identificador de la propiedad.
        /// </summary>
        public int IdProperty { get; set; }

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
        /// Obtiene o establece el Nobre del propietario.
        /// </summary>
        public string OwnerName { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece el identificador del tipo de propiedad.
        /// </summary>
        public int PropertyType { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del tipo de propiedad.
        /// </summary>
        public string PropertyTypeName { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la fecha de creación de la propiedad.
        /// </summary>
        public DateTime CreateDate { get; set; }


        /// <summary>
        /// Obtiene o establece la fecha de la última modificación de la propiedad.
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de la propiedad.
        /// </summary>
        public string Status { get; set; } = string.Empty;

        public string? PropertyImages { get; set; }

        /// <summary>
        /// Convierte un objeto Property a un objeto PropertyDto de forma implícita.
        /// </summary>
        /// <param name="property">Objeto Property que se va a convertir a PropertyDto.</param>
        /// <returns>Un nuevo objeto PropertyDto con la información de la propiedad.</returns>

        public static implicit operator PropertyDto(Property property)
        {
            return new PropertyDto
            {
                IdProperty = property.IdProperty,
                Name = property.Name,
                Details = property.Details,
                CodeInternal = property.CodeInternal,
                City = property.City,
                Country = property.Country,
                Price = property.Price,
                Address = property.Address,
                Bedrooms = property.Bedrooms,
                Bathrooms = property.Bathrooms,
                Year = property.Year,
                IdOwner = property.IdOwner,
                OwnerName = property.Owner.Name,
                PropertyType = property.IdPropertyType,
                PropertyTypeName = property.PropertyType.Name,
                Status = property.Status,
                CreateDate = property.CreateDate,
                LastModified = property.LastModified,
                PropertyImages = property.PropertyImages.OrderByDescending(t => t.IdPropertyImage).FirstOrDefault()?.FilePath
            };
        }
    }
}