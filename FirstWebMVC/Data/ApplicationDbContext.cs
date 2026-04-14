using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Models; // Đảm bảo có dòng này để nó hiểu class Product

namespace FirstWebMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DÒNG NÀY CỰC KỲ QUAN TRỌNG - THIẾU NÓ SẼ BỊ LỖI CS1061
        public DbSet<Product> Products { get; set; } 
    }
}