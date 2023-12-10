using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RealEstateManager.Domain.FilesManager;
using System.Diagnostics.CodeAnalysis;

namespace RealEstateManager.Infrastructure.FilesManager
{
    [ExcludeFromCodeCoverage]
    public class FilesManagerAdapter(IConfiguration configuration) : IFilesManager
    {
        private readonly string? storagePath = configuration["PathFileTarget"];

        public async Task<string> SaveImageAsync(IFormFile imageDto)
        {
            // Verificar si el directorio de almacenamiento existe, si no, créalo
            if (!Directory.Exists(storagePath))
            {
                Directory.CreateDirectory(storagePath);
            }

            // Obtener el nombre del archivo del objeto IFormFile
            var fileName = $"{DateTime.Today}{imageDto.Name}"; // Cambiar la extensión según el tipo de archivo

            // Construir la ruta completa del archivo
            var filePath = Path.Combine(storagePath, fileName);

            // Verificar si ya existe un archivo con el mismo nombre
            if (File.Exists(filePath))
            {
                throw new InvalidOperationException("Ya existe un archivo con el mismo nombre.");
            }

            // Copiar el archivo al directorio de almacenamiento
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageDto.CopyToAsync(stream);
            }

            // Devolver la ruta del archivo guardado
            return filePath;
        }
    }
}
