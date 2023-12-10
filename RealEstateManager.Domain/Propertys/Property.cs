using RealEstateManager.Domain.Owners;
using RealEstateManager.Domain.PropertyImages;
using RealEstateManager.Domain.PropertyTypes;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateManager.Domain.Propertys
{
    /// <summary>
    /// Clase que representa una propiedad inmobiliaria.
    /// </summary>
    public class Property
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
        public int Bedrooms { get; set; } = 0;

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
        [ForeignKey(nameof(IdOwner))]
        public int IdOwner { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del tipo de propiedad.
        /// </summary>
        [ForeignKey(nameof(IdPropertyType))]
        public int IdPropertyType { get; set; }

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
        public string Status { get; set; } = null!;

        /// <summary>
        /// Obtiene o establece la relación con el propietario de la propiedad.
        /// </summary>
        public virtual Owner Owner { get; set; }

        /// <summary>
        /// Obtiene o establece la relación con el tipo de propiedad de la propiedad.
        /// </summary>
        public virtual PropertyType PropertyType { get; set; }

        /// <summary>
        /// Obtiene o establece la colección de imágenes asociadas a la propiedad.
        /// </summary>
        public virtual ICollection<PropertyImage> PropertyImages { get; set; }
    }

}
