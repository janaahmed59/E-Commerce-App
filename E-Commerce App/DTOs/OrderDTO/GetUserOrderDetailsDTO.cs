using E_Commerce_App.Enum;

namespace E_Commerce_App.DTOs.OrderDTO
{
    public class GetUserOrderDetailsDTO
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItemDTO> Items;
    }
}
