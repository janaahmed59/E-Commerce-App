namespace E_Commerce_App.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public List<Order> Orders { get; set; } // one user can make many orders
        public Cart Cart { get; set; } // one user have one Cart (for one order)
        
    }
}
