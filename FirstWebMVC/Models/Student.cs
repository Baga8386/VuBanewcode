using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace FirstWebMVC.Models
    {
        public class Student
        {
            [Key]
            public string StudentID { get; set; }
            public string FullName { get; set; }
            public string? Email { get; set; }

            // Khóa ngoại trỏ đến Faculty
            public int FacultyID { get; set; }
            
            [ForeignKey("FacultyID")]
            public Faculty? Faculty { get; set; }
        }
    }
    