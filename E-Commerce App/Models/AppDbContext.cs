using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId);
            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderItems)
                .WithOne(oi => oi.Product)
                .HasForeignKey(oi => oi.ProductId);
            modelBuilder.Entity<Product>()
                .HasMany(p => p.CartItems)
                .WithOne(ci => ci.Product)
                .HasForeignKey(ci => ci.ProductId);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId);

            // User
            modelBuilder.Entity<User>()
                .Property(o => o.Name)
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .Property(o => o.Email)
                .HasMaxLength(150);
            modelBuilder.Entity<User>()
                .Property(o => o.Password)
                .IsRequired();
            // Product
            modelBuilder.Entity<Product>()
                .Property(o => o.Name)
                .HasMaxLength(100);
            modelBuilder.Entity<Product>()
                .Property(o => o.Description)
                .HasMaxLength(500);
            modelBuilder.Entity<Product>()
                .Property(o => o.Price)
                .HasPrecision(15, 2).IsRequired();
            // orderitem
            modelBuilder.Entity<OrderItem>()
                .Property(o => o.Price)
                .HasPrecision(15, 2)
                .IsRequired();
            // order
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalPrice)
                .HasPrecision(15, 2)
                .IsRequired();
            modelBuilder.Entity<Order>()
                .Property(o => o.Status)
                .HasDefaultValue("Pending");
            // Category
            modelBuilder.Entity<Category>()
                .Property(o => o.Name)
                .HasMaxLength(100);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
    // User 1 -> M Orders
    //user 1 -> 1 Cart
    //product 1 -> M OrderItems
    // product 1 -> M CartItems
    // product M -> 1 Category
    // order 1 -> M OrderItems
    // Cart 1 -> M CartItems

}
