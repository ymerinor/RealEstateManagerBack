using Microsoft.AspNetCore.Mvc;
using Moq;
using RealEstateManager.Application.Property.Dto;
using RealEstateManager.Application.Property.Interfaces;
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
            var mockPropertyProductServices = new Mock<IPropertyServices>();
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
            var mockPropertyProductServices = new Mock<IPropertyServices>();
            mockPropertyProductServices.Setup(service => service.CreateAsync(It.IsAny<PropertyRequestDto>()))
                .ReturnsAsync(PropertyFixtures.PropertyRequestDtoTest);
            var controller = new PropertyController(mockPropertyProductServices.Object);
            //Act
            await controller.Post(PropertyFixtures.PropertyRequestDtoTest);
            //Assert
            mockPropertyProductServices.Verify(
            service => service.CreateAsync(It.IsAny<PropertyRequestDto>()), Times.Once());
        }
    }
}
