using E_Commerce_App.Models;
namespace E_Commerce_App.Repo
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public User GetByEmail(string email);
    }
}
