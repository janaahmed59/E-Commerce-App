using E_Commerce_App.DTOs.OrderDTO;
using E_Commerce_App.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Repo
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public List<Order> GetOrderByUser(int userId)
        {
            return _context.Orders.Where(o => o.UserId == userId).ToList();
        }
        public Order GetOrderWithitems(int orderId)
        {
            return _context.Orders.Include(o=> o.OrderItems)
                                    .FirstOrDefault(o => o.Id == orderId);

        }
    }
}
