using E_Commerce_App.Models;
namespace E_Commerce_App.Repo
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public List<Order> GetOrderByUser(int userId);
        public Order GetOrderWithitems(int orderId);
    }
}
