using RealEstateManager.Infrastructure;
using RealEstateManager.Infrastructure.Repository;
using RealEstateManager.UnitTest.System.Fixtures;

namespace RealEstateManager.UnitTest.System.Infrastructure.Repository
{
    public class TestPropertyRepository : IDisposable
    {
        private readonly SqliteInMemoryFixture _fixture;

        public TestPropertyRepository()
        {
            _fixture = new SqliteInMemoryFixture();
        }

        [Fact]
        public async Task CretePropertyAsync_Sucess()
        {
            using var context = new RealEstateManagerDbContext(_fixture.CreateOptions<RealEstateManagerDbContext>());
            // Arrange
            var repository = new PropertyRepository(context);
            // Act
            var result = await repository.CreateAsync(PropertyFixtures.PropertyCreateTest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(PropertyFixtures.PropertyCreateTest.Name, result.Name);
        }


        [Fact]
        public async Task CretePropertyAsync_Update()
        {
            using var context = new RealEstateManagerDbContext(_fixture.CreateOptions<RealEstateManagerDbContext>());
            // Arrange
            var repository = new PropertyRepository(context);
            // Act
            var result = await repository.UpdateAsync(PropertyFixtures.PropertyTest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(PropertyFixtures.PropertyTest.Name, result.Name);
        }


        [Fact]
        public async Task GetAllAsync_Sucess()
        {
            using var context = new RealEstateManagerDbContext(_fixture.CreateOptions<RealEstateManagerDbContext>());
            // Arrange
            var repository = new PropertyRepository(context);
            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Any());
        }

        [Fact]
        public async Task GetByIdAsync_Sucess()
        {
            using var context = new RealEstateManagerDbContext(_fixture.CreateOptions<RealEstateManagerDbContext>());
            // Arrange
            var repository = new PropertyRepository(context);
            // Act
            var result = await repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByIdAsync_Empty()
        {
            using var context = new RealEstateManagerDbContext(_fixture.CreateOptions<RealEstateManagerDbContext>());
            // Arrange
            var repository = new PropertyRepository(context);
            // Act
            var result = await repository.GetByIdAsync(2);

            // Assert
            Assert.Null(result);
        }


        public void Dispose() => _fixture.Dispose();
    }
}
