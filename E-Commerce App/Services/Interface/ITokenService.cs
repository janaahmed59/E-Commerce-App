using E_Commerce_App.Models;

namespace E_Commerce_App.Services.Interface
{
    public interface ITokenService
    {
        public string CreateToken(User user);
    }
}
