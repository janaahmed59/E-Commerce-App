using E_Commerce_App.DTOs.OrderDTO;
using E_Commerce_App.Services.Interface;
using E_Commerce_App.UnitOfWorkLayer.Interface;
using E_Commerce_App.Models;
using E_Commerce_App.Enum;
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

            var cart = _unit.cart.GetCartWithItems(userid);
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
                OrderDate = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                OrderItems = new List<OrderItem>(),
            };
            foreach (var item in cart.CartItems) // 4
            {
                if(item.Quantity > item.Product.Stock)
                {
                    throw new Exception($"Not enough stock for product {item.Product.Name}");
                }

                order.OrderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Product.Price
                });
                item.Product.Stock -= item.Quantity;
                order.TotalPrice += item.Product.Price * item.Quantity; // 5
            }
            if (order.Status == OrderStatus.Cancelled)
            {
                foreach (var item1 in order.OrderItems)
                {
                    item1.Product.Stock += item1.Quantity;
                }
            }
            _unit.order.Create(order); // 6
            cart.CartItems.Clear(); // 7
            _unit.Save(); // 8
        }
        public IEnumerable<GetUserOrderDTO> GetMyOrders(int userid)
        {
            var orders = _unit.order.GetOrderByUser(userid);
          
            return orders.OrderByDescending(o => o.OrderDate)
                         .Select(o => new GetUserOrderDTO
                         {
                             OrderId = o.Id,
                             OrderDate = o.OrderDate,
                             Status = o.Status,
                             TotalPrice = o.TotalPrice
                         }).ToList();
        }
        public GetUserOrderDetailsDTO GetOrderById(int orderid, int userid)
        {
            var order = _unit.order.GetOrderWithitems(orderid, userid);
           
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
            var Repo = _unit.order;
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
            var orderRepo = _unit.order;
            var order = orderRepo.GetById(orderid);
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            order.Status = dto.NewStatus;
            orderRepo.Update(order);
            _unit.Save();
        }
        public void CancelOrder(int orderid , int userid)
        {
            var orderRepo = _unit.order;
            var order = orderRepo.GetById(orderid);
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            if(order.UserId != userid)
            {
                throw new UnauthorizedAccessException();
            }
            if(order.Status == OrderStatus.Delivered)
            {
                throw new Exception("Delivered orders cannot be cancelled.");
            }
            if (order.Status == OrderStatus.Cancelled)
            {
                throw new Exception("Order is already cancelled.");
            }
            order.Status = OrderStatus.Cancelled;
            orderRepo.Update(order);
            _unit.Save();
        }
    }
}
