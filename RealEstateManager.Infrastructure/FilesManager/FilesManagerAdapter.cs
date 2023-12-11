using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RealEstateManager.Domain.FilesManager;
using System.Diagnostics.CodeAnalysis;

namespace RealEstateManager.Infrastructure.FilesManager
{
    [ExcludeFromCodeCoverage]
    /// <summary>
    /// Implementación de <see cref="IFilesManager"/> que gestiona la creación y almacenamiento de archivos.
    /// </summary>
    public class FilesManagerAdapter(IConfiguration configuration) : IFilesManager
    {
        private readonly string? storagePath = configuration["PathFileTarget"];

        /// <inheritdoc/>
        public async Task<string> SaveImageAsync(IFormFile formFile)
        {
            if (!Directory.Exists(storagePath))
            {
                Directory.CreateDirectory(storagePath);
            }
            var fileName = $"{Guid.NewGuid()}-{formFile.FileName}";

            var pathImage = Path.Combine(storagePath, fileName);

            if (File.Exists(pathImage))
            {
                throw new InvalidOperationException("Ya existe un archivo con el mismo nombre.");
            }
            using (var stream = new FileStream(pathImage, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }
            return pathImage;

        }
    }
}
