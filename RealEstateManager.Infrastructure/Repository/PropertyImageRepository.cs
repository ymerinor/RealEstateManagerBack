using RealEstateManager.Domain.PropertyImages;
using RealEstateManager.Domain.Repository;

namespace RealEstateManager.Infrastructure.Repository
{
    /// <summary>
    /// Repositorio para operaciones relacionadas con imágenes de propiedades en la base de datos.
    /// Implementa la interfaz <see cref="IPropertyImageRepository"/>.
    /// </summary>
    public class PropertyImageRepository(RealEstateManagerDbContext realEstateManagerDbContext) : IPropertyImageRepository
    {
        private readonly RealEstateManagerDbContext _realEstateManagerDbContext = realEstateManagerDbContext;

        /// <summary>
        /// Crea una nueva entidad de imagen de propiedad en la base de datos.
        /// </summary>
        /// <param name="propertyImage">Entidad de imagen de propiedad a crear.</param>
        /// <returns>La entidad de imagen de propiedad creada.</returns>
        public async Task<PropertyImage> CreateAsync(PropertyImage propertyImage)
        {
            await _realEstateManagerDbContext.PropertyImage.AddAsync(propertyImage);
            await _realEstateManagerDbContext.SaveChangesAsync();
            return propertyImage;
        }
    }
}
