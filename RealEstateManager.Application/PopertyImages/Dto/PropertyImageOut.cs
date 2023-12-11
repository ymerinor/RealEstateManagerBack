using RealEstateManager.Domain.PropertyImages;

namespace RealEstateManager.Application.PopertyImages.Dto
{
    public class PropertyImageOut
    {
        /// <summary>
        /// Obtiene o establece el identificador de la imagen de la propiedad.
        /// </summary>
        public int IdPropertyImage { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la propiedad asociada mediante la clave externa.
        /// </summary>
        public int IdProperty { get; set; }

        /// <summary>
        /// Obtiene o establece la ruta del archivo de la imagen. Es obligatorio.
        /// </summary>
        public required string FilePath { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica si la imagen está habilitada. Es obligatorio.
        /// </summary>
        public bool Enabled { get; set; }

        public static implicit operator PropertyImageOut(PropertyImage property)
        {
            return new PropertyImageOut
            {
                Enabled = property.Enabled,
                FilePath = property.FilePath,
                IdPropertyImage = property.IdPropertyImage,
                IdProperty = property.IdProperty,
            };
        }
    }
}
