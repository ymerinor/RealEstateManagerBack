using Microsoft.AspNetCore.Http;

namespace RealEstateManager.Application.PopertyImages.Dto
{
    /// <summary>
    /// Clase que representa la información de una imagen asociada a una propiedad.
    /// </summary>
    public class PropertyImageDto
    {
        /// <summary>
        /// Obtiene o establece el identificador de la propiedad a la que pertenece la imagen.
        /// </summary>
        public required int IdProperty { get; set; }

        /// <summary>
        /// Obtiene o establece el archivo de imagen asociado a la propiedad.
        /// </summary>
        public required IFormFile ImageFile { get; set; }
    }

}
