using E_Commerce_App.DTOs.UserDTO;

namespace E_Commerce_App.Services.Interface
{
    public interface IAuthenticationService
    {
        public AuthDTO Register(RegisterUserDTO register);
        public AuthDTO Login(LoginDTO login);

    }
}
