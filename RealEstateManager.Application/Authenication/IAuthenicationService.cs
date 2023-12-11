using RealEstateManager.Application.Authenication.Dto;

namespace RealEstateManager.Application.Authenication
{
    public interface IAuthenicationService
    {
        /// <summary>
        /// Metodo para realizar el proceso de login de la API
        /// </summary>
        /// <param name="userDto">informacion de usuario que inicia sesion</param>
        /// <exception cref="UnauthorizedAccessException">en caso de la informacion del usuario ser errada</exception>
        string Login(UserLoginDto userDto);
    }
}
