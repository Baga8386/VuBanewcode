using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Models; // Đảm bảo có dòng này để nó hiểu class Product

namespace FirstWebMVC.Data
{
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    
    public DbSet<Category> Categories { get; set; } 
    public DbSet<Student> Students { get; set; }
}
}