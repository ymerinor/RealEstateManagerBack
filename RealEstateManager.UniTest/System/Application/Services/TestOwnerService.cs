using Moq;
using RealEstateManager.Application.Owners.Service;
using RealEstateManager.Domain.Owners;
using RealEstateManager.Domain.Repository;
using RealEstateManager.UnitTest.System.Fixtures;

namespace RealEstateManager.UnitTest.System.Application.Services
{
    [TestFixture]
    [Category("UnitTest")]
    public class TestOwnerService
    {
        private Mock<IOwnerRepository> _mockRepository;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new Mock<IOwnerRepository>();
        }

        [Test]
        public async Task GetOwnerById_ExistsProduct()
        {
            //Arrage
            _mockRepository
                .Setup(repository => repository.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(PropertyFixtures.OwnerCreateTest);
            var serviceProduct = new OwnerService(_mockRepository.Object);
            //Act
            var result = await serviceProduct.GetByIdAsync(1);
            //Assert
            Assert.That(result != null, Is.True);
        }

        [Test]
        public async Task GetAll_Product()
        {
            //Arrage
            _mockRepository
                .Setup(repository => repository.GetAllAsync())
                .ReturnsAsync(new List<Owner> { PropertyFixtures.OwnerCreateTest });
            var serviceProduct = new OwnerService(_mockRepository.Object);
            //Act
            var result = await serviceProduct.GetAllAsync();
            //Assert
            Assert.That(result.Any());
        }
    }
}
