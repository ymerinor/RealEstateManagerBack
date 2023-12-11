using Microsoft.Extensions.Configuration;
using Moq;
using RealEstateManager.Application.Authenication.Dto;
using RealEstateManager.Application.Authentication;
using RealEstateManager.UnitTest.System.Fixtures;

namespace RealEstateManager.UniTest.System.Application.Services
{
    [TestFixture]
    public class TestAuthenicationService
    {

        [Test]
        public void Login_Sucess()
        {
            //Arrage
            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(x => x["JwtSetting:SecretKey"]).Returns("C946F639EF11A125FEF72D3E93191");
            mockConfiguration.Setup(x => x["JwtSetting:UserEmailTest"]).Returns("yeinermeri@gmail.com");
            mockConfiguration.Setup(x => x["JwtSetting:PasswordTest"]).Returns("0123456789");

            var serviceProperty = new AuthenicationService(mockConfiguration.Object);
            //Act
            var result = serviceProperty.Login(PropertyFixtures.TestLogin);
            //Assert
            Assert.NotNull(result);
        }
        [Test]
        public void Login_Fail_Unauthorized()
        {
            //Arrage
            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(x => x["JwtSetting:SecretKey"]).Returns("C946F639EF11A125FEF72D3E93191");
            mockConfiguration.Setup(x => x["JwtSetting:UserEmailTest"]).Returns("yeinermeri@gmail.com");
            mockConfiguration.Setup(x => x["JwtSetting:PasswordTest"]).Returns("0123456789");

            var serviceProperty = new AuthenicationService(mockConfiguration.Object);
            //Act && Assert
            Assert.Throws<UnauthorizedAccessException>(() => serviceProperty.Login(new UserLoginDto { Email = "yeinermeri@gmail.com", Password = "" }));

        }
    }
}
