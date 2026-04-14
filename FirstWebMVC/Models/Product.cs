using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [DisplayName("Tên sản phẩm")]
        [StringLength(100, ErrorMessage = "Tên không được quá 100 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá")]
        [Range(1000, 100000000, ErrorMessage = "Giá phải từ 1,000đ đến 100,000,000đ")]
        [DisplayName("Giá bán")]
        public decimal Price { get; set; }
    }
}