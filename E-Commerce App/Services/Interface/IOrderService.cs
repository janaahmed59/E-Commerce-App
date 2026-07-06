using E_Commerce_App.DTOs.OrderDTO;

namespace E_Commerce_App.Services.Interface
{
    public interface IOrderService
    {
        public void PlaceOrder(int userid);
        public IEnumerable<GetUserOrderDTO> GetMyOrders(int userid);
        public GetUserOrderDetailsDTO GetOrderById(int orderid);
        public IEnumerable<GetUserOrderDTO> GetAllOrders();
        public void UpdateOrderStatus(int orderid, UpdateStatusDTO dto);
        public void CancelOrder(int orderid);
    }
}
// |-- CreateOrder
// |-- GetMyOrders
// |-- GetOrderDetails
// |-- GetAllOrders
// |-- UpdateOrderStatus
// |-- CancelOrder