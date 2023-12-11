using Moq;
using RealEstateManager.Application.Authenication;
using RealEstateManager.Controllers;
using RealEstateManager.UnitTest.System.Fixtures;

namespace RealEstateManager.UniTest.System.Controllers
{
    [TestFixture]
    public class TestAuthController
    {
        [Test]
        public void Login_Succes_Invoke()
        {
            //Arrage
            var mockAutProductServices = new Mock<IAuthenicationService>();
            var controller = new AuthController(mockAutProductServices.Object);
            //Act
            var result = controller.Login(PropertyFixtures.TestLogin);
            //Assert
            Assert.Null(result.Value);
        }
    }
}
