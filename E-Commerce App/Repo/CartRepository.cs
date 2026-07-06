using E_Commerce_App.Models;
using E_Commerce_App.Repo;
using Microsoft.EntityFrameworkCore;
namespace E_Commerce_App.Repo
{
    public class CartRepository : GenericRepository<Cart>,  ICartRepository
    {
        private readonly AppDbContext _context;
        public CartRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public Cart GetCartWithItems(int userId)
        {
            return _context.Carts.Include(c => c.CartItems)
                                     .ThenInclude(c => c.Product)
                                .FirstOrDefault(c => c.UserId == userId);   
        }

    }
}
