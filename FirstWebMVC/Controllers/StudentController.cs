using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Data;
using FirstWebMVC.Models;
using OfficeOpenXml;

namespace FirstWebMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Import(IFormFile file)
        {
            if (file == null || file.Length == 0) return View("Index");
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream)) 
                {
                    // Đọc Sheet đầu tiên
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;
                    List<Student> studentList = new List<Student>();

                    // Vòng lặp từ dòng 2 (bỏ qua tiêu đề)
                    for (int row = 2; row <= rowCount; row++)
                    {
                        studentList.Add(new Student
                        {
                            StudentID = worksheet.Cells[row, 1].Value?.ToString() ?? "",
                            FullName = worksheet.Cells[row, 2].Value?.ToString() ?? "",
                            Email = worksheet.Cells[row, 3].Value?.ToString() ?? ""
                        });
                    }

                    if (studentList.Count > 0)
                    {
                        _context.Students.AddRange(studentList);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}