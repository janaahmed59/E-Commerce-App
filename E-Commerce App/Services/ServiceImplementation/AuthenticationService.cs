using E_Commerce_App.DTOs.UserDTO;
using E_Commerce_App.Migrations;
using E_Commerce_App.Models;
using E_Commerce_App.Repo;
using E_Commerce_App.Services.Interface;
using E_Commerce_App.UnitOfWorkLayer.Interface;
using E_Commerce_App.UnitOfWorkLayer;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;

namespace E_Commerce_App.Services.ServiceImplementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unit;
        private readonly ITokenService _token;
        public AuthenticationService(IUnitOfWork unitOfWork, ITokenService tokenServicecs)
        {
            _unit = unitOfWork;
            _token = tokenServicecs;
        }
        public AuthDTO Register(RegisterUserDTO register)
        {
            // Correct usage: call Repository<User>() and then use a method to check for existence
            var userRepo = _unit.user.GetByEmail(register.Email);

            if (userRepo != null)
                throw new Exception("Email exists");

            using var hmac = new HMACSHA512();
            var user = new User
            {
                Name = register.Name,
                Email = register.Email,
                PasswordSalt = Convert.ToBase64String(hmac.Key),
                Password = Convert.ToBase64String(
                    hmac.ComputeHash(
                        Encoding.UTF8.GetBytes(register.Password))),
                Role = "Customer"
            };

            _unit.user.Create(user);
            _unit.Save();
            return new AuthDTO
            {
                Token = _token.CreateToken(user),
                Name = user.Name,
                Role = user.Role
            };

        }
        public AuthDTO Login(LoginDTO login)
        {
            var userRepo = _unit.user.GetByEmail(login.Email);
            if (userRepo == null) throw new Exception("Invalid Email");

            var salt = Convert.FromBase64String(userRepo.PasswordSalt);
            using var hmac = new HMACSHA512(salt);

            var hash =
            Convert.ToBase64String(
            hmac.ComputeHash(
            Encoding.UTF8.GetBytes(login.Password)));

            if (hash != userRepo.Password)
                throw new Exception("Invalid password");

            return new AuthDTO
            {
                Token = _token.CreateToken(userRepo),
                Name = userRepo.Name,
                Role = userRepo.Role
            };
        }
    }
}
