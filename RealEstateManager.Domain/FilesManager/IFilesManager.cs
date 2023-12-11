using Microsoft.AspNetCore.Http;

namespace RealEstateManager.Domain.FilesManager
{
    public interface IFilesManager
    {

        /// <summary>
        /// Guarda una imagen en el directorio de almacenamiento especificado.
        /// </summary>
        /// <param name="imageDto">Archivo de imagen a guardar.</param>
        /// <returns>Ruta del archivo guardado.</returns>
        string SaveImageAsync(IFormFile imageDto);
    }
}
