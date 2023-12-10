using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RealEstateManager.Application.PopertyImages.Dto;
using RealEstateManager.Controllers;

namespace RealEstateManager.UnitTest.System.Controllers
{
    public class TestPropertyImageController
    {
        [Test]
        public async Task Get_Succes_StatusCode200()
        {
            //Arrage
            var fileMock = new Mock<IFormFile>();
            var controller = new PropertyImageController();
            //Act
            var result = (OkObjectResult)await controller.Post(new PropertyImageDto { IdProperty = 1, ImageFile = fileMock.Object });
            //Assert
            Assert.IsTrue(result.StatusCode == 200);
        }
    }
}
