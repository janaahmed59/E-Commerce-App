namespace E_Commerce_App.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public User User { get; set; } // order have user
        public List<OrderItem> OrderItems { get; set; } // order have order items
    }
}
