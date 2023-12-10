using Microsoft.AspNetCore.Http;
using Moq;
using RealEstateManager.Application.PopertyImages.Dto;
using RealEstateManager.Application.PopertyImages.Services;
using RealEstateManager.Domain.FilesManager;
using RealEstateManager.Domain.PropertyImages;
using RealEstateManager.Domain.Repository;
using RealEstateManager.UnitTest.System.Fixtures;

namespace RealEstateManager.UniTest.System.Application.Services
{
    [TestFixture]
    public class TestPropertyImageService
    {
        private Mock<IPropertyImageRepository> _mockPropertyRepository;
        private Mock<IPropertyRepository> _mockRepository;
        private Mock<IFilesManager> _mockFilesManager;
        [SetUp]
        public void Setup()
        {
            _mockPropertyRepository = new Mock<IPropertyImageRepository>();
            _mockRepository = new Mock<IPropertyRepository>();
            _mockFilesManager = new Mock<IFilesManager>();
        }

        [Test]
        public async Task TestPropertyImage_Sucess()
        {
            //Arrage
            var fileMock = new Mock<IFormFile>();
            _mockRepository.Setup(repository => repository.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(PropertyFixtures.PropertySemillaTest);
            _mockPropertyRepository.Setup(repositoryImagen => repositoryImagen.CreateAsync(It.IsAny<PropertyImage>())).ReturnsAsync(PropertyFixtures.PropertyImageSemilla);
            _mockFilesManager.Setup(repositoryfiles => repositoryfiles.SaveImageAsync(It.IsAny<IFormFile>())).ReturnsAsync("D:\\StorageProperty");
            var serviceProperty = new PropertyImageService(_mockRepository.Object, _mockPropertyRepository.Object, _mockFilesManager.Object);
            //Act
            var result = await serviceProperty.AddImagePropertyAsync(new PropertyImageDto { IdProperty = 1, ImageFile = fileMock.Object });
            //Assert
            Assert.NotNull(result);
        }
    }
}
