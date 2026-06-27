using E_Commerce_App.Models;
using E_Commerce_App.Repo;
namespace E_Commerce_App.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        public IGenericRepository<T> Repository<T>() where T : class;
        public void Save();

    }
}
