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
            var mockPropertyServices = new Mock<IPropertyService>();
            mockPropertyServices.Setup(service => service.CreateAsync(It.IsAny<PropertyRequestDto>()))
                .ReturnsAsync(PropertyFixtures.PropertyRequestDtoTest);
            var controller = new PropertyController(mockPropertyServices.Object);
            //Act
            await controller.Post(PropertyFixtures.PropertyRequestDtoTest);
            //Assert
            mockPropertyServices.Verify(
            service => service.CreateAsync(It.IsAny<PropertyRequestDto>()), Times.Once());
        }

        [Fact]
        public async Task Post_Succes_StatusCode400()
        {
            //Arrage
            var mockPropertyServices = new Mock<IPropertyService>();
            var controller = new PropertyController(mockPropertyServices.Object);
            //Act
            var result = (BadRequestObjectResult)await controller.Post(PropertyFixtures.PropertyRequestBadRequestDtoTest);
            //Assert
            Assert.True(result.StatusCode == 400);
        }

        [Fact]
        public async Task Get_Succes_StatusCode200()
        {
            //Arrage
            var mockPropertyServices = new Mock<IPropertyService>();
            var controller = new PropertyController(mockPropertyServices.Object);
            //Act
            var result = (OkObjectResult)await controller.Get();
            //Assert
            Assert.True(result.StatusCode == 200);
        }

        [Fact]
        public async Task Get_Succes_InvokeServiceOnce()
        {
            //Arrage
            var mockPropertyServices = new Mock<IPropertyService>();
            mockPropertyServices.Setup(service => service.GetAllAsync())
                .ReturnsAsync(new List<PropertyDto> { PropertyFixtures.PropertyGetTest });
            var controller = new PropertyController(mockPropertyServices.Object);
            //Act
            await controller.Get();
            //Assert
            mockPropertyServices.Verify(service => service.GetAllAsync());
        }
    }
}
