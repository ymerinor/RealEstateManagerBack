using Moq;
using RealEstateManager.Application.Common.Excepciones;
using RealEstateManager.Application.Propertys.Dto;
using RealEstateManager.Application.Propertys.Services;
using RealEstateManager.Domain.Propertys;
using RealEstateManager.Domain.Repository;
using RealEstateManager.UnitTest.System.Fixtures;

namespace RealEstateManager.UnitTest.System.Application.Services
{
    [TestFixture]
    public class TestPropertyService
    {
        [Test]
        public async Task CreateProperty_Sucess()
        {
            //Arrage
            var mockRepository = new Mock<IPropertyRepository>();
            var mockOwnerRepository = new Mock<IOwnerRepository>();
            mockRepository.Setup(repository => repository.CreateAsync(It.IsAny<Property>())).ReturnsAsync(PropertyFixtures.PropertySemillaTest);
            mockOwnerRepository.Setup(repositoryOwner => repositoryOwner.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(PropertyFixtures.OwnerCreateTest);

            var serviceProperty = new PropertyService(mockRepository.Object, mockOwnerRepository.Object);
            //Act
            var result = await serviceProperty.CreateAsync(PropertyFixtures.PropertyRequestDtoTest);
            //Assert
            Assert.That((result.Name == PropertyFixtures.PropertyRequestDtoTest.Name));
        }

        [Test]
        public void CreateProperty_NoFoundExceptionOwner()
        {
            //Arrage
            var mockRepository = new Mock<IPropertyRepository>();
            var mockOwnerRepository = new Mock<IOwnerRepository>();
            mockRepository.Setup(repository => repository.CreateAsync(It.IsAny<Property>())).ReturnsAsync(PropertyFixtures.PropertySemillaTest);

            var serviceProperty = new PropertyService(mockRepository.Object, mockOwnerRepository.Object);
            //Act && Assert
            Assert.ThrowsAsync<NoFoundException>(async () =>
            {
                await serviceProperty.CreateAsync(PropertyFixtures.PropertyRequestDtoTest);
            });

        }

        [Test]
        public async Task GetAllProperty_Sucess()
        {
            //Arrage
            var mockRepository = new Mock<IPropertyRepository>();
            var mockOwnerRepository = new Mock<IOwnerRepository>();
            mockRepository.Setup(repository => repository.GetAllAsync()).ReturnsAsync(new List<Property> { PropertyFixtures.PropertyTest });

            var serviceProperty = new PropertyService(mockRepository.Object, mockOwnerRepository.Object);
            //Act
            var result = await serviceProperty.GetAllAsync();
            //Assert
            Assert.That(result.Any());
        }

        [Test]
        public async Task GetAllPropertyEmpty_Error()
        {
            //Arrage
            var mockRepository = new Mock<IPropertyRepository>();
            var mockOwnerRepository = new Mock<IOwnerRepository>();

            var serviceProperty = new PropertyService(mockRepository.Object, mockOwnerRepository.Object);
            //Act
            var result = await serviceProperty.GetAllAsync();
            //Assert
            Assert.That(result.Any(), Is.False);
        }

        [Test]
        public async Task ChangePreciAsync_Sucess()
        {
            //Arrage
            var mockRepository = new Mock<IPropertyRepository>();
            var mockOwnerRepository = new Mock<IOwnerRepository>();

            mockRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(PropertyFixtures.PropertyTest);
            mockRepository.Setup(repository => repository.UpdateAsync(It.IsAny<Property>())).ReturnsAsync(PropertyFixtures.PropertyTest);

            var serviceProperty = new PropertyService(mockRepository.Object, mockOwnerRepository.Object);
            //Act
            var result = await serviceProperty.ChangePreciAsync(1, new ChangePriceProperty { Preci = 10000 });
            //Assert
            Assert.That(result != null, Is.True);
        }

        [Test]
        public void ChangePreciAsync_EmptyProperty()
        {
            //Arrage
            var mockRepository = new Mock<IPropertyRepository>();
            var mockOwnerRepository = new Mock<IOwnerRepository>();
            mockRepository.Setup(repository => repository.UpdateAsync(It.IsAny<Property>())).ReturnsAsync(PropertyFixtures.PropertyTest);

            var serviceProperty = new PropertyService(mockRepository.Object, mockOwnerRepository.Object);
            //Act && Assert

            Assert.ThrowsAsync<NoFoundException>(async () => await serviceProperty.ChangePreciAsync(2, new ChangePriceProperty { Preci = 10000 }));
        }
        [Test]
        public async Task UpdateAsync_Sucess()
        {
            //Arrage
            var mockRepository = new Mock<IPropertyRepository>();
            var mockOwnerRepository = new Mock<IOwnerRepository>();

            mockOwnerRepository.Setup(repositoryOwner => repositoryOwner.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(PropertyFixtures.OwnerCreateTest);
            mockRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(PropertyFixtures.PropertyTest);
            mockRepository.Setup(repository => repository.UpdateAsync(It.IsAny<Property>())).ReturnsAsync(PropertyFixtures.PropertyTest);

            var serviceProperty = new PropertyService(mockRepository.Object, mockOwnerRepository.Object);
            //Act
            var result = await serviceProperty.UpdateAsync(1, PropertyFixtures.PropertyRequestDtoTest);
            //Assert
            Assert.That(result != null, Is.True);
        }
        [Test]
        public void UpdateAsync_NoExistsProperty()
        {
            //Arrage
            var mockRepository = new Mock<IPropertyRepository>();
            var mockOwnerRepository = new Mock<IOwnerRepository>();

            mockOwnerRepository.Setup(repositoryOwner => repositoryOwner.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(PropertyFixtures.OwnerCreateTest);
            mockRepository.Setup(repository => repository.UpdateAsync(It.IsAny<Property>())).ReturnsAsync(PropertyFixtures.PropertyTest);

            var serviceProperty = new PropertyService(mockRepository.Object, mockOwnerRepository.Object);
            //Act && Assert

            Assert.ThrowsAsync<NoFoundException>(async () => await serviceProperty.UpdateAsync(1, PropertyFixtures.PropertyRequestDtoTest));
        }
    }
}
