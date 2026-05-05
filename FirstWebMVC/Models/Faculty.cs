using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyID { get; set; }
        [Required]
        public string FacultyName { get; set; } = string.Empty;
        // Một khoa có nhiều sinh viên
        public ICollection<Student>? Students { get; set; }
    }
}