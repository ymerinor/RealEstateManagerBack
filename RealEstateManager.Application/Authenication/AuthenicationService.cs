using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RealEstateManager.Application.Authenication;
using RealEstateManager.Application.Authenication.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealEstateManager.Application.Authentication
{
    /// <summary>
    /// Inicializador de la <class>AuthenicationService</class>
    /// </summary>
    /// <param name="configuration"></param>
    public class AuthenicationService(IConfiguration configuration) : IAuthenicationService
    {
        /// <summary>
        /// Dependencia de IConfiguration
        /// </summary>
        private readonly IConfiguration _configuration = configuration;

        /// <inheritdoc/>
        public string Login(UserLoginDto userLoginDto)
        {
            var userIdValid = userLoginDto.Email.Equals("yeinermeri@gmail.com") && userLoginDto.Password.Equals("0123456789");
            if (!userIdValid)
            {
                throw new UnauthorizedAccessException("usuario  o contraseña invalide.");
            }

            var token = GetToken(userLoginDto.Email);

            return token;
        }

        /// <inheritdoc/>
        public string GetToken(string username)
        {
            var jwtSecretKetBytes = Encoding.UTF8.GetBytes(_configuration["JwtSetting:SecretKey"] ?? string.Empty);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, username));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtSecretKetBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string token = tokenHandler.WriteToken(tokenConfig);

            return token;
        }
    }
}
