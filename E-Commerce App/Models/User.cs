namespace E_Commerce_App.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Role { get; set; }
        public List<Order> Orders { get; set; } // one user can make many orders
        public Cart Cart { get; set; } // one user have one Cart (for one order)
                                       // add to Cart , remove from cart , get Cart , change quantity, 
                                       // user -> get all product, get product details , filter by category(search for Category), search for Product
                                       // Admin add product , deleteproduct , update product details,
                                       // payement for product
                                       // Admin -> create Category , update, delete , getCategorybyId, Get All Category
                                       // buy -> get cart -> create order -> ge orderitems -> get total -> decrease stock -> clear cart =========> Create Order (orderService)
                                       // user -> get my orders , getorderdetails , updateOrderStatus(Admin)


        //AuthService
        // |
        // |-- Register
        // |-- Login
        // |-- GenerateToken


        //UserService
        // |
        // |-- GetProfile
        // |-- UpdateProfile
        // |-- ChangePassword
        // |-- DeleteAccount


        //ProductService
        // |
        // |-- GetAllProducts
        // |-- GetProductById
        // |-- CreateProduct
        // |-- UpdateProduct
        // |-- DeleteProduct
        // |-- SearchProducts
        // |-- FilterByCategory



        //CategoryService
        // |
        // |-- GetCategories
        // |-- CreateCategory
        // |-- UpdateCategory
        // |-- DeleteCategory


        //CartService
        // |
        // |-- GetCart
        // |-- AddToCart
        // |-- RemoveFromCart
        // |-- UpdateQuantity


        //OrderService
        // |
        // |-- CreateOrder
        // |-- GetMyOrders
        // |-- GetOrderDetails
        // |-- GetAllOrders
        // |-- UpdateOrderStatus



    }
}
