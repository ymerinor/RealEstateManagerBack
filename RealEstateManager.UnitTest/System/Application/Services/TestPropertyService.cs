using Moq;
using RealEstateManager.Application.Propertys.Services;
using RealEstateManager.Domain.Propertys;
using RealEstateManager.Domain.Repository;
using RealEstateManager.UnitTest.System.Fixtures;

namespace RealEstateManager.UnitTest.System.Application.Services
{
    public class TestPropertyService
    {
        [Fact]
        public async Task CreateProperty_Sucess()
        {
            //Arrage
            var mockRepository = new Mock<IPropertyRepository>();
            mockRepository.Setup(repository => repository.CreateAsync(It.IsAny<Property>())).ReturnsAsync(PropertyFixtures.PropertyTest);

            var serviceProperty = new PropertyService(mockRepository.Object);
            //Act
            var result = await serviceProperty.CreateAsync(PropertyFixtures.PropertyRequestDtoTest);
            //Assert
            Assert.Equal(result.Name, PropertyFixtures.PropertyRequestDtoTest.Name);
        }

    }
}
