namespace E_Commerce_App.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; } // one order item can have many products
        public Order Order { get; set; } // one order item can have many orders
    }
}
