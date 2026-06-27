namespace E_Commerce_App.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; } // one cart item can have many products
        public Cart Cart { get; set; } // one cart item can have many carts
    }
}
