namespace E_Commerce_App.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; } // one category can have many products
    }
}
