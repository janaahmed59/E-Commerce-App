using E_Commerce_App.Models;
namespace E_Commerce_App.Repo
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public IEnumerable<Order> GetOrderByUser(int userId);
        public Order GetOrderWithitems(int orderId , int userId);
        public Order GetOrderById(int orderId, int userId);
    }
}
