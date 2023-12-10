using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RealEstateManager.Infrastructure;

namespace RealEstateManager.UnitTest.System.Fixtures
{
    public class SqliteInMemoryFixture : IDisposable
    {
        private readonly SqliteConnection _connection;

        public SqliteInMemoryFixture()
        {
            SQLitePCL.Batteries_V2.Init();
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
            // Llamar al método de semilla por defecto
            Seed();
        }

        public DbContextOptions<TDbContext> CreateOptions<TDbContext>() where TDbContext : DbContext
        {
            return new DbContextOptionsBuilder<TDbContext>()
                .UseSqlite(_connection)
                .Options;
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public void Seed()
        {
            using var context = new RealEstateManagerDbContext(CreateOptions<RealEstateManagerDbContext>());
            context.Database.EnsureCreated();

            // Agrega información de semilla según sea necesario
            if (!context.Owner.Any())
            {
                context.Owner.AddRange(PropertyFixtures.OwnerCreateTest);

                context.SaveChanges();
            }

            if (!context.PropertyType.Any())
            {
                context.PropertyType.AddRange(PropertyFixtures.PropertyTypeCreateTest);

                context.SaveChanges();
            }

            if (!context.Property.Any())
            {
                context.Property.AddRange(PropertyFixtures.PropertySemillaTest);

                context.SaveChanges();
            }
        }
    }
}
