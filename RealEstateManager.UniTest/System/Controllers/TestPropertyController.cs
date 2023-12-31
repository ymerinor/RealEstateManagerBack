﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using RealEstateManager.Api.Controllers;
using RealEstateManager.Application.Propertys.Dto;
using RealEstateManager.Application.Propertys.Interfaces;
using RealEstateManager.UnitTest.System.Fixtures;
namespace RealEstateManager.UnitTest.System.Controllers
{
    [TestFixture]
    public class TestPropertyController
    {
        [Test]
        public async Task Post_Succes_StatusCode200()
        {
            //Arrage
            var mockPropertyProductServices = new Mock<IPropertyService>();
            var controller = new PropertyController(mockPropertyProductServices.Object);
            //Act
            var result = (OkObjectResult)await controller.Post(PropertyFixtures.PropertyRequestDtoTest);
            //Assert
            Assert.IsTrue(result.StatusCode == 200);
        }

        [Test]
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

        [Test]
        public async Task Post_Succes_StatusCode400()
        {
            //Arrage
            var mockPropertyServices = new Mock<IPropertyService>();
            var controller = new PropertyController(mockPropertyServices.Object);
            //Act
            var result = (BadRequestObjectResult)await controller.Post(PropertyFixtures.PropertyRequestBadRequestDtoTest);
            //Assert
            Assert.IsTrue(result.StatusCode == 400);
        }

        [Test]
        public async Task Get_Succes_StatusCode200()
        {
            //Arrage
            var mockPropertyServices = new Mock<IPropertyService>();
            var controller = new PropertyController(mockPropertyServices.Object);
            //Act
            var result = (OkObjectResult)await controller.Get();
            //Assert
            Assert.IsTrue(result.StatusCode == 200);
        }

        [Test]
        public async Task Get_Succes_InvokeServiceOnce()
        {
            //Arrage
            var mockPropertyServices = new Mock<IPropertyService>();
            mockPropertyServices.Setup(service => service.GetAllAsync())
                .ReturnsAsync(new List<PropertyDto> { PropertyFixtures.PropertyTest });
            var controller = new PropertyController(mockPropertyServices.Object);
            //Act
            await controller.Get();
            //Assert
            mockPropertyServices.Verify(service => service.GetAllAsync());
        }

        [Test]
        public async Task Patch_Succes_StatusCode200()
        {
            //Arrage
            var mockPropertyServices = new Mock<IPropertyService>();
            var controller = new PropertyController(mockPropertyServices.Object);
            //Act
            var result = (OkObjectResult)await controller.Patch(1, new ChangePriceProperty { Preci = 1000 });
            //Assert
            Assert.IsTrue(result.StatusCode == 200);
        }

        [Test]
        public async Task Patch_Succes_InvokeServiceOnce()
        {
            //Arrage
            var mockPropertyServices = new Mock<IPropertyService>();
            mockPropertyServices.Setup(service => service.ChangePreciAsync(It.IsAny<int>(), It.IsAny<ChangePriceProperty>()))
                .ReturnsAsync(PropertyFixtures.PropertyTest);
            var controller = new PropertyController(mockPropertyServices.Object);
            //Act
            await controller.Patch(1, new ChangePriceProperty { Preci = 1000 });
            //Assert
            mockPropertyServices.Verify(
            service => service.ChangePreciAsync(It.IsAny<int>(), It.IsAny<ChangePriceProperty>()), Times.Once());
        }
        [Test]
        public async Task Put_Succes_StatusCode200()
        {
            //Arrage
            var mockPropertyProductServices = new Mock<IPropertyService>();
            var controller = new PropertyController(mockPropertyProductServices.Object);
            //Act
            var result = (OkObjectResult)await controller.Put(1, PropertyFixtures.PropertyRequestDtoTest);
            //Assert
            Assert.IsTrue(result.StatusCode == 200);
        }

        [Test]
        public async Task Put_Succes_InvokeServiceOnce()
        {
            //Arrage
            var mockPropertyServices = new Mock<IPropertyService>();
            mockPropertyServices.Setup(service => service.UpdateAsync(It.IsAny<int>(), It.IsAny<PropertyRequestDto>()))
                .ReturnsAsync(PropertyFixtures.PropertyTest);
            var controller = new PropertyController(mockPropertyServices.Object);
            //Act
            await controller.Put(1, PropertyFixtures.PropertyRequestDtoTest);
            //Assert
            mockPropertyServices.Verify(
            service => service.UpdateAsync(It.IsAny<int>(), It.IsAny<PropertyRequestDto>()), Times.Once());
        }

        [Test]
        public async Task Put_Succes_StatusCode400()
        {
            //Arrage
            var mockPropertyServices = new Mock<IPropertyService>();
            var controller = new PropertyController(mockPropertyServices.Object);
            //Act
            var result = (BadRequestObjectResult)await controller.Put(1, PropertyFixtures.PropertyRequestBadRequestDtoTest);
            //Assert
            Assert.IsTrue(result.StatusCode == 400);
        }

        [Test]
        public async Task Post_filtres_StatusCode200()
        {
            //Arrage
            var mockPropertyProductServices = new Mock<IPropertyService>();
            var controller = new PropertyController(mockPropertyProductServices.Object);
            //Act
            var result = (OkObjectResult)await controller.GetWithFilters(PropertyFixtures.FiltersQueryTest);
            //Assert
            Assert.IsTrue(result.StatusCode == 200);
        }
    }
}
