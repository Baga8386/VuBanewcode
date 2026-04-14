using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Data; 
var builder = WebApplication.CreateBuilder(args);

// 1. Cấu hình dịch vụ (Services) - Nằm sau 'builder' và TRƯỚC 'builder.Build()'
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 2. Cấu hình HTTP request pipeline (Middleware)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// 3. Cấu hình Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

// 4. Lệnh chạy ứng dụng - LUÔN LUÔN NẰM CUỐI CÙNG
app.Run();