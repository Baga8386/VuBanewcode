using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên khách hàng")]
        [StringLength(100)]
        [Display(Name = "Họ và tên")]
        public string? FullName { get; set; }

        [EmailAddress(ErrorMessage = "Địa chỉ Email không hợp lệ")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Số điện thoại không đúng định dạng")]
        public string? PhoneNumber { get; set; }

        // Một khách hàng có nhiều đơn hàng (Quan hệ 1 - Nhiều)
        public ICollection<Order>? Orders { get; set; }
    }
}