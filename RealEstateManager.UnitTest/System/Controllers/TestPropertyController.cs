using Microsoft.AspNetCore.Mvc;
using Moq;
using RealEstateManager.Application.Propertys.Dto;
using RealEstateManager.Application.Propertys.Interfaces;
using RealEstateManager.Controllers;
using RealEstateManager.UnitTest.System.Fixtures;
namespace RealEstateManager.UnitTest.System.Controllers
{
    public class TestPropertyController
    {
        [Fact]
        public async Task Post_Succes_StatusCode200()
        {
            //Arrage
            var mockPropertyProductServices = new Mock<IPropertyService>();
            var controller = new PropertyController(mockPropertyProductServices.Object);
            //Act
            var result = (OkObjectResult)await controller.Post(PropertyFixtures.PropertyRequestDtoTest);
            //Assert
            Assert.True(result.StatusCode == 200);
        }

        [Fact]
        public async Task Post_Succes_InvokeServiceOnce()
        {
            //Arrage
            var mockPropertyProductServices = new Mock<IPropertyService>();
            mockPropertyProductServices.Setup(service => service.CreateAsync(It.IsAny<PropertyRequestDto>()))
                .ReturnsAsync(PropertyFixtures.PropertyRequestDtoTest);
            var controller = new PropertyController(mockPropertyProductServices.Object);
            //Act
            await controller.Post(PropertyFixtures.PropertyRequestDtoTest);
            //Assert
            mockPropertyProductServices.Verify(
            service => service.CreateAsync(It.IsAny<PropertyRequestDto>()), Times.Once());
        }

        [Fact]
        public async Task Post_Succes_StatusCode400()
        {
            //Arrage
            var mockPropertyProductServices = new Mock<IPropertyService>();
            var controller = new PropertyController(mockPropertyProductServices.Object);
            //Act
            var result = (BadRequestObjectResult)await controller.Post(PropertyFixtures.PropertyRequestBadRequestDtoTest);
            //Assert
            Assert.True(result.StatusCode == 400);
        }
    }
}
