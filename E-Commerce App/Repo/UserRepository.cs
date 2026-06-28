using E_Commerce_App.Models;
using Microsoft.EntityFrameworkCore;
namespace E_Commerce_App.Repo
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public User GetByEmail(string email)
        {
            return _context.Users
                .FirstOrDefault(x => x.Email == email);
        }
    }
}
