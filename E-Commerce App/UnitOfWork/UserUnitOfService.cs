using E_Commerce_App.Models;
using E_Commerce_App.Repo;
using E_Commerce_App.UnitOfWork.Interface;
namespace E_Commerce_App.UnitOfWork
{
    public class UserUnitOfService : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UserUnitOfService(AppDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<T> Repository<T>()  where T : class
        {
            return new GenericRepository<T>(_context);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
