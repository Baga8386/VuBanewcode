using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FirstWebMVC.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; } = new Product();

        [ValidateNever]
        public IEnumerable<SelectListItem>? CategoryList { get; set; } 
    }
}