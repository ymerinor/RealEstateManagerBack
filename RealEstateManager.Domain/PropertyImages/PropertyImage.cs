using RealEstateManager.Domain.Propertys;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateManager.Domain.PropertyImages
{
    /// <summary>
    /// Clase que representa una imagen asociada a una propiedad inmobiliaria.
    /// </summary>
    public class PropertyImage
    {
        /// <summary>
        /// Obtiene o establece el identificador de la imagen de la propiedad.
        /// </summary>
        public int IdPropertyImage { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la propiedad asociada mediante la clave externa.
        /// </summary>
        [ForeignKey(nameof(IdProperty))]
        public int IdProperty { get; set; }

        /// <summary>
        /// Obtiene o establece la ruta del archivo de la imagen. Es obligatorio.
        /// </summary>
        public required string FilePath { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica si la imagen está habilitada. Es obligatorio.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Obtiene o establece la relación con la propiedad asociada a la imagen.
        /// </summary>
        public virtual required Property Property { get; set; }
    }

}
