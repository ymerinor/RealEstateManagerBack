using Moq;
using RealEstateManager.Application.Common.Excepciones;
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
            var mockOwnerRepository = new Mock<IOwnerRepository>();
            mockRepository.Setup(repository => repository.CreateAsync(It.IsAny<Property>())).ReturnsAsync(PropertyFixtures.PropertyTest);
            mockOwnerRepository.Setup(repositoryOwner => repositoryOwner.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(PropertyFixtures.OwnerCreateTest);

            var serviceProperty = new PropertyService(mockRepository.Object, mockOwnerRepository.Object);
            //Act
            var result = await serviceProperty.CreateAsync(PropertyFixtures.PropertyRequestDtoTest);
            //Assert
            Assert.Equal(result.Name, PropertyFixtures.PropertyRequestDtoTest.Name);
        }

        [Fact]
        public async Task CreateProperty_NoFoundExceptionOwner()
        {
            //Arrage
            var mockRepository = new Mock<IPropertyRepository>();
            var mockOwnerRepository = new Mock<IOwnerRepository>();
            mockRepository.Setup(repository => repository.CreateAsync(It.IsAny<Property>())).ReturnsAsync(PropertyFixtures.PropertyTest);

            var serviceProperty = new PropertyService(mockRepository.Object, mockOwnerRepository.Object);
            //Act && Assert
            await Assert.ThrowsAsync<NoFoundException>(async () => await serviceProperty.CreateAsync(PropertyFixtures.PropertyRequestDtoTest));

        }


        [Fact]
        public async Task GetAllProperty_Sucess()
        {
            //Arrage
            var mockRepository = new Mock<IPropertyRepository>();
            var mockOwnerRepository = new Mock<IOwnerRepository>();
            mockRepository.Setup(repository => repository.GetAllAsync()).ReturnsAsync(new List<Property> { PropertyFixtures.PropertyGetTest });

            var serviceProperty = new PropertyService(mockRepository.Object, mockOwnerRepository.Object);
            //Act
            var result = await serviceProperty.GetAllAsync();
            //Assert
            Assert.True(result.Any());
        }

        [Fact]
        public async Task GetAllPropertyEmpty_Error()
        {
            //Arrage
            var mockRepository = new Mock<IPropertyRepository>();
            var mockOwnerRepository = new Mock<IOwnerRepository>();

            var serviceProperty = new PropertyService(mockRepository.Object, mockOwnerRepository.Object);
            //Act
            var result = await serviceProperty.GetAllAsync();
            //Assert
            Assert.False(result.Any());
        }
    }
}
