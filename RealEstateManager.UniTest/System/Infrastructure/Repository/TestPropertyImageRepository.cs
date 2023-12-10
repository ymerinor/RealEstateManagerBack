using RealEstateManager.Infrastructure;
using RealEstateManager.Infrastructure.Repository;
using RealEstateManager.UnitTest.System.Fixtures;

namespace RealEstateManager.UniTest.System.Infrastructure.Repository
{
    [TestFixture]
    public class TestPropertyImageRepository
    {
        private SqliteInMemoryFixture _fixture;

        [SetUp]
        public void Stup()
        {
            _fixture = new SqliteInMemoryFixture();
        }


        [Test]
        public async Task CretePropertyAsync_Sucess()
        {
            using var context = new RealEstateManagerDbContext(_fixture.CreateOptions<RealEstateManagerDbContext>());
            // Arrange
            var repository = new PropertyImageRepository(context);
            // Act
            var result = await repository.CreateAsync(PropertyFixtures.PropertyCreateImageSemilla);

            // Assert
            Assert.That(result != null, Is.True);
        }
    }
}
