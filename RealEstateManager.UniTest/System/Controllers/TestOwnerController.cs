using Microsoft.AspNetCore.Mvc;
using Moq;
using RealEstateManager.Api.Controllers;
using RealEstateManager.Application.Owners.Interface;
using RealEstateManager.Domain.Owners;
using RealEstateManager.UnitTest.System.Fixtures;

namespace RealEstateManager.UnitTest.System.Controllers
{
    [TestFixture]
    public class TestOwnerController
    {
        [Test]
        public async Task Get_Succes_StatusCode200()
        {
            //Arrage
            var mockOwnerService = new Mock<IOwnerService>();
            mockOwnerService
                .Setup(service => service.GetAllAsync())
                .ReturnsAsync(new List<Owner> { PropertyFixtures.OwnerCreateTest });
            var controller = new OwnerController(mockOwnerService.Object);
            //Act
            var result = (OkObjectResult)await controller.Get();
            //Assert
            Assert.That(result.StatusCode == 200);
        }
    }
}
