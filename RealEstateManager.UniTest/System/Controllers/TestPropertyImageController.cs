using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RealEstateManager.Application.PopertyImages.Dto;
using RealEstateManager.Application.PopertyImages.Interfaces;
using RealEstateManager.Controllers;
using RealEstateManager.UnitTest.System.Fixtures;

namespace RealEstateManager.UnitTest.System.Controllers
{
    [TestFixture]
    public class TestPropertyImageController
    {

        Mock<IPropertyImageService> _mockPropertyImagesServices;

        [SetUp]
        public void Setup()
        {
            _mockPropertyImagesServices = new Mock<IPropertyImageService>();
        }

        [Test]
        public async Task Get_Succes_StatusCode200()
        {
            //Arrage
            var fileMock = new Mock<IFormFile>();
            var controller = new PropertyImageController(_mockPropertyImagesServices.Object);
            //Act
            var result = (OkObjectResult)await controller.Post(new PropertyImageDto { IdProperty = 1, ImageFile = fileMock.Object });
            //Assert
            Assert.IsTrue(result.StatusCode == 200);
        }

        [Test]
        public async Task Post_Succes_InvokeServiceOnce()
        {
            //Arrage
            var fileMock = new Mock<IFormFile>();
            _mockPropertyImagesServices.Setup(service => service.AddImagePropertyAsync(It.IsAny<PropertyImageDto>()))
                .ReturnsAsync(PropertyFixtures.PropertyImageOutTest);
            var controller = new PropertyImageController(_mockPropertyImagesServices.Object);
            //Act
            await controller.Post(new PropertyImageDto { IdProperty = 1, ImageFile = fileMock.Object });
            //Assert
            _mockPropertyImagesServices.Verify(
            service => service.AddImagePropertyAsync(It.IsAny<PropertyImageDto>()), Times.Once());
        }
    }
}
