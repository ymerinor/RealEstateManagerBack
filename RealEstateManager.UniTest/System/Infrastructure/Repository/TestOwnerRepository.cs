using RealEstateManager.Infrastructure;
using RealEstateManager.Infrastructure.Repository;
using RealEstateManager.UnitTest.System.Fixtures;

namespace RealEstateManager.UnitTest.System.Infrastructure.Repository
{

    [TestFixture]
    public class TestOwnerRepository
    {
        private readonly SqliteInMemoryFixture _fixture;

        public TestOwnerRepository()
        {
            _fixture = new SqliteInMemoryFixture();
        }
        [Test]
        public async Task GetByIdAsync_WithValidId_ShouldReturnOwner()
        {
            using var context = new RealEstateManagerDbContext(_fixture.CreateOptions<RealEstateManagerDbContext>());
            var repository = new OwnerRepository(context);
            // Act
            var result = await repository.GetByIdAsync(1);
            // Assert
            Assert.NotNull(result);
        }
        [Test]
        public async Task GetAll_ShouldReturnOwner()
        {
            using var context = new RealEstateManagerDbContext(_fixture.CreateOptions<RealEstateManagerDbContext>());
            var repository = new OwnerRepository(context);
            // Act
            var result = await repository.GetAllAsync();
            // Assert
            Assert.IsTrue(result.Any());
        }
    }
}
