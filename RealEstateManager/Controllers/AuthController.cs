using Microsoft.AspNetCore.Mvc;
using RealEstateManager.Application.Authenication;
using RealEstateManager.Application.Authenication.Dto;

namespace RealEstateManager.Controllers
{
    /// <summary>
    /// Builder
    /// </summary>
    /// <param name="logger"></param>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthenicationService authenicationService) : ControllerBase
    {

        private readonly IAuthenicationService _authenicationService = authenicationService;

        /// <summary>
        /// Iniciar sesion
        /// </summary>
        /// <param name="user">Usuario con Coreo y clave validos</param>
        /// <remarks>
        ///    POST /login
        ///    {"email": "yeinermeri@gmail.com","password": "0123456789"}
        /// </remarks>
        /// <returns>Token de sesión</returns>
        /// <response code="200">Token de sesión</response>
        /// <response code="401">No autorizado</response>
        [HttpPost("login", Name = "login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<string> Login([FromBody] UserLoginDto user)
        {
            return _authenicationService.Login(user);
        }
    }
}
