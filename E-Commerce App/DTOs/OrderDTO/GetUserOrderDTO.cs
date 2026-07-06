namespace E_Commerce_App.DTOs.OrderDTO
{
    public class GetUserOrderDTO
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
    }
}
