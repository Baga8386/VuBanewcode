using Microsoft.AspNetCore.Mvc;

namespace YourProjectName.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            // Sử dụng ViewBag để truyền dữ liệu sang View
            ViewBag.HoTen = "VuVietBa";
            ViewBag.MaSinhVien = "2221050464";
            
            return View();
        }
    }
}