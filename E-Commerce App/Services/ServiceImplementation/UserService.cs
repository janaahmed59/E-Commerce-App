using E_Commerce_App.DTOs.UserDTO;
using E_Commerce_App.Models;
using E_Commerce_App.UnitOfWork.Interface;
using E_Commerce_App.Services.Interface;
using E_Commerce_App.Repo;
namespace E_Commerce_App.Services.ServiceImplementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<GetallDTO> GetAllUsers()
        {
            var repo = _unitOfWork.Repository<User>();
            return repo.GetAll().Select(u => new GetallDTO
            {
                Name = u.Name,
                Email = u.Email,
            }).ToList();
        }
        public void UpdateProfile(int id, UpdatePassDTO Dto)
        {
            var repo = _unitOfWork.Repository<User>();
            var user = repo.GetById(id);
            if (user != null)
            {
                user.Password = Dto.NewPassword;
                repo.Update(user);
                _unitOfWork.Save();
            }
        }
        public void Updateusername(int id, UpdateUsernameDTO Dto)
        {
            var repo = _unitOfWork.Repository<User>();
            var user = repo.GetById(id);
            if (user != null)
            {
                user.Name = Dto.NewUsername;
                repo.Update(user);
                _unitOfWork.Save();
            }
        }
        public void RegisterUser(RegisterUserDTO dto)
        {
            var repo = _unitOfWork.Repository<User>();
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                Role = "Cutomer"
            };
            repo.Add(user);
            _unitOfWork.Save();
        }
        public void DeleteProfile(int id)
        {
            var repo = _unitOfWork.Repository<User>();
            var user = repo.GetById(id);
            if (user != null)
            {
                repo.Delete(user);
                _unitOfWork.Save();
            }

        }
    }
}
