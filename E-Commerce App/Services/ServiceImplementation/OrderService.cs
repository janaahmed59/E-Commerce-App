using E_Commerce_App.DTOs.OrderDTO;
using E_Commerce_App.Services.Interface;
using E_Commerce_App.UnitOfWorkLayer.Interface;
using E_Commerce_App.Models;

namespace E_Commerce_App.Services.ServiceImplementation
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unit;
        public OrderService(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public void PlaceOrder(int userid)
        {
            // 1. Get the user's cart
            // 2. Check if the cart is empty
            // 3. Create a new order
            // 4. Add order items from the cart to the order
            // 5. Calculate the total price of the order
            // 6. Save the order to the database
            // 7. Clear the user's cart
            // 8. Save changes to the database
            var orderRepo = _unit.Repository<Order>();
            var cartRepo = _unit.Repository<Cart>();
            var cart = cartRepo.GetAll().FirstOrDefault(u => u.UserId == userid); // 1
            if(cart == null)
            {
                throw new Exception("Cart not found");
            }
            if(!cart.CartItems.Any()) // 2
            {
                throw new Exception("Cart is empty");
            }
            var order = new Order // 3
            {
                UserId = userid,
                OrderDate = DateTime.Now,
                Status = "Pending",
                OrderItems = new List<OrderItem>(),
            };
            foreach (var item in cart.CartItems) // 4
            {
                order.OrderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Product.Price
                });
                order.TotalPrice += item.Product.Price * item.Quantity; // 5
            }
            orderRepo.Create(order); // 6
            cart.CartItems.Clear(); // 7
            _unit.Save(); // 8
        }
        public IEnumerable<GetUserOrderDTO> GetMyOrders(int userid)
        {
            var Repo = _unit.Repository<Order>();
            var orders = Repo.GetAll().Where(o => o.UserId == userid);
            return orders.OrderByDescending(o => o.OrderDate)
                         .Select(o => new GetUserOrderDTO
                         {
                             OrderId = o.Id,
                             OrderDate = o.OrderDate,
                             Status = o.Status,
                             TotalPrice = o.TotalPrice
                         }).ToList();
        }
        public GetUserOrderDetailsDTO GetOrderById(int orderid)
        {
            var repo = _unit.Repository<Order>();
            var order = repo.GetById(orderid);
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            return new GetUserOrderDetailsDTO
            {
                OrderId = order.Id,
                OrderDate = order.OrderDate,
                Status = order.Status,
                TotalPrice = order.TotalPrice,
                Items = order.OrderItems.Select(o => new OrderItemDTO
                {
                    ProductName = o.Product.Name,
                    Quantity = o.Quantity,
                    Total = o.Quantity * o.Price,
                }).ToList()
            };
        }
        public IEnumerable<GetUserOrderDTO> GetAllOrders() // Admin only
        {
            var Repo = _unit.Repository<Order>();
            var orders = Repo.GetAll();
            var orderdto = orders.OrderByDescending(o => o.OrderDate)
                                .Select(o => new GetUserOrderDTO
                                {
                                    OrderId = o.Id,
                                    OrderDate = o.OrderDate,
                                    Status = o.Status,
                                    TotalPrice = o.TotalPrice
                                });
            return orderdto;
        }
        public void UpdateOrderStatus(int orderid, UpdateStatusDTO dto)
        {

            var orderRepo = _unit.Repository<Order>();
            var order = orderRepo.GetById(orderid);
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            order.Status = dto.NewStatus;
            orderRepo.Update(order);
            _unit.Save();
        }
        public void CancelOrder(int orderid)
        {
            var orderRepo = _unit.Repository<Order>();
            var order = orderRepo.GetById(orderid);
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            order.Status = "Cancelled";
            orderRepo.Update(order);
            _unit.Save();
        }
    }
}
