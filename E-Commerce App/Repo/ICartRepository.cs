using E_Commerce_App.Models;
namespace E_Commerce_App.Repo
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        public Cart GetCartWithItems(int userId);
    }
}
