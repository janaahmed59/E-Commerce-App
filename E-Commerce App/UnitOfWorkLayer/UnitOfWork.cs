using E_Commerce_App.Models;
using E_Commerce_App.Repo;
using E_Commerce_App.UnitOfWorkLayer.Interface;
namespace E_Commerce_App.UnitOfWorkLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IUserRepository user { get; set; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            user = new UserRepository(context);
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
