using Microsoft.EntityFrameworkCore;
using RealEstateManager.Domain.Owners;
using RealEstateManager.Domain.PropertyImages;
using RealEstateManager.Domain.PropertyTypes;
using RealEstateManager.Infrastructure.Configurations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace RealEstateManager.Infrastructure
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="RealEstateManagerDbContext"/>.
    /// </summary>
    /// <param name="options">Las opciones a ser utilizadas por el contexto.</param>
    [ExcludeFromCodeCoverage]
    public class RealEstateManagerDbContext(DbContextOptions<RealEstateManagerDbContext> options) : DbContext(options)
    {

        /// <summary>
        /// Obtiene o establece el DbSet para la entidad Owner.
        /// </summary>

        public DbSet<Owner> Owner { get; set; }
        /// <summary>
        /// Obtiene o establece el DbSet para la entidad PropertyType.
        /// </summary>
        public DbSet<PropertyType> PropertyType { get; set; }
        /// <summary>
        /// Obtiene o establece el DbSet para la entidad Property.
        /// </summary>
        public DbSet<Domain.Propertys.Property> Property { get; set; }
        /// <summary>
        /// Obtiene o establece el DbSet para la entidad PropertyImage.
        /// </summary>
        public DbSet<PropertyImage> PropertyImage { get; set; }

        // <summary>
        /// Configura el modelo que es descubierto por convención a partir de los tipos de entidad expuestos en las propiedades <see cref="DbSet{TEntity}"/> en el contexto derivado.
        /// </summary>
        /// <param name="modelBuilder">El constructor que se está utilizando para construir el modelo para este contexto.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PropertysConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyImageConfiguration());
            base.OnModelCreating(modelBuilder);

        }

    }
}
