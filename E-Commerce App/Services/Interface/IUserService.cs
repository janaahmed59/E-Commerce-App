using E_Commerce_App.DTOs.UserDTO;

namespace E_Commerce_App.Services.Interface
{
    public interface IUserService
    {
        public List<GetallDTO> GetAllUsers();
        public void UpdateProfile(int id, UpdatePassDTO Dto);
        public void Updateusername(int id, UpdateUsernameDTO Dto);
        public void DeleteProfile(int id);

    }
}
