using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Data;
using FirstWebMVC.Models;
using FirstWebMVC.Models.ViewModels; // Để dùng ProductVM
using Microsoft.EntityFrameworkCore; // Quan trọng: Để dùng .Include()
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace FirstWebMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        // --- INDEX: Hiển thị danh sách và Tìm kiếm ---
        public IActionResult Index(string searchString)
        {
            // Lấy danh sách sản phẩm kèm theo thông tin Category tương ứng
            var products = _db.Products.Include(u => u.Category).AsQueryable();

            // Logic tìm kiếm cho Buổi 12
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString));
            }

            ViewData["CurrentFilter"] = searchString;
            List<Product> objProductList = products.ToList();
            return View(objProductList);
        }

        // --- CREATE (GET): Hiển thị form thêm mới ---
        public IActionResult Create()
        {
            ProductVM productVM = new()
            {
                CategoryList = _db.Categories.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
            return View(productVM);
        }

        // --- CREATE (POST): Lưu thiết bị mới ---
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(obj.Product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            // Nếu lỗi, load lại danh sách Category trước khi trả về View
            obj.CategoryList = _db.Categories.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(obj);
        }

        // --- EDIT (GET): Load dữ liệu cũ vào form sửa ---
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return View("NotFound");

            ProductVM productVM = new()
            {
                CategoryList = _db.Categories.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = _db.Products.Find(id)
            };

            if (productVM.Product == null) return View("NotFound");

            return View(productVM);
        }

        // --- EDIT (POST): Lưu cập nhật ---
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Update(obj.Product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // --- DELETE (GET): Xác nhận xóa ---
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return View("NotFound");

            // Dùng Include để hiện tên Danh mục ở trang xác nhận xóa
            var productFromDb = _db.Products.Include(u => u.Category).FirstOrDefault(u => u.Id == id);

            if (productFromDb == null) return View("NotFound");

            return View(productFromDb);
        }

        // --- DELETE (POST): Thực hiện xóa ---
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Products.Find(id);
            if (obj == null) return View("NotFound");

            _db.Products.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}