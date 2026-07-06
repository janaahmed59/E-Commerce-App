using E_Commerce_App.Models;
using E_Commerce_App.Repo;
namespace E_Commerce_App.UnitOfWorkLayer.Interface
{
    public interface IUnitOfWork
    {
        public IGenericRepository<T> Repository<T>() where T : class;
        public IUserRepository user { get; set; }
        public ICartRepository cart { get; set; }
        public IOrderRepository order { get; set; }
        public void Save();

    }
}
