using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên loại không được để trống")]
        public string Name { get; set; }

        public int DisplayOrder { get; set; } 
    }
}