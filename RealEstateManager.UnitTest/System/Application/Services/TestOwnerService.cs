using Moq;
using RealEstateManager.Application.Owners;
using RealEstateManager.Domain.Repository;
using RealEstateManager.UnitTest.System.Fixtures;

namespace RealEstateManager.UnitTest.System.Application.Services
{
    public class TestOwnerService
    {
        [Fact]
        public async Task GetOwnerById_ExistsProduct()
        {
            //Arrage
            var mockRepository = new Mock<IOwnerRepository>();
            mockRepository
                .Setup(repository => repository.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(PropertyFixtures.OwnerCreateTest);
            var serviceProduct = new OwnerService(mockRepository.Object);
            //Act
            var result = await serviceProduct.GetByIdAsync(1);
            //Assert
            Assert.NotNull(result);
        }
    }
}
