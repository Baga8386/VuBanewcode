namespace FirstWebMVC.Models
{
    public class Product
    {
        // View đang gọi "Id", hãy đảm bảo bạn có Id hoặc ProductID
        // Nếu View dùng .Id, bạn nên để là Id
        public int Id { get; set; } 

        public string Name { get; set; } = "";

        // Lỗi báo thiếu 'Price'
        public decimal Price { get; set; } 

        // Lỗi báo thiếu 'CategoryId'
        public int CategoryId { get; set; } 

        // Navigation property
        public Category? Category { get; set; }
    }
}