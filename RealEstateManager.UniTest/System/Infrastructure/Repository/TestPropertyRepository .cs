using RealEstateManager.Infrastructure;
using RealEstateManager.Infrastructure.Repository;
using RealEstateManager.UnitTest.System.Fixtures;

namespace RealEstateManager.UnitTest.System.Infrastructure.Repository
{
    [TestFixture]
    public class TestPropertyRepository : IDisposable
    {
        private readonly SqliteInMemoryFixture _fixture;

        public TestPropertyRepository()
        {
            _fixture = new SqliteInMemoryFixture();
        }

        [Test]
        public async Task CretePropertyAsync_Sucess()
        {
            using var context = new RealEstateManagerDbContext(_fixture.CreateOptions<RealEstateManagerDbContext>());
            // Arrange
            var repository = new PropertyRepository(context);
            // Act
            var result = await repository.CreateAsync(PropertyFixtures.PropertyCreateTest);

            // Assert
            Assert.That(result != null, Is.True);
        }


        [Test]
        public async Task CretePropertyAsync_Update()
        {
            using var context = new RealEstateManagerDbContext(_fixture.CreateOptions<RealEstateManagerDbContext>());
            // Arrange
            var repository = new PropertyRepository(context);
            // Act
            var result = await repository.UpdateAsync(PropertyFixtures.PropertyTest);

            // Assert
            Assert.That(result != null, Is.True);
        }


        [Test]
        public async Task GetAllAsync_Sucess()
        {
            using var context = new RealEstateManagerDbContext(_fixture.CreateOptions<RealEstateManagerDbContext>());
            // Arrange
            var repository = new PropertyRepository(context);
            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.That(result.Any());
        }

        [Test]
        public async Task GetByIdAsync_Sucess()
        {
            using var context = new RealEstateManagerDbContext(_fixture.CreateOptions<RealEstateManagerDbContext>());
            // Arrange
            var repository = new PropertyRepository(context);
            // Act
            var result = await repository.GetByIdAsync(1);

            // Assert
            Assert.That(result != null, Is.True);
        }

        public void Dispose() => _fixture.Dispose();
    }
}
