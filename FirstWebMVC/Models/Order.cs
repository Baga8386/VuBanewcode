using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebMVC.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Display(Name = "Ngày lập đơn")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        // Khóa ngoại liên kết tới Khách hàng
        [Required]
        public int CustomerId { get; set; }
        
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        // Một đơn hàng có nhiều chi tiết sản phẩm
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}