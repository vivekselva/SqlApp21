using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SqlApp21.Models;
using SqlApp21.Services;

namespace SqlApp21.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products;
        public void OnGet()
        {
            ProductService productService = new ProductService();
            Products = productService.GetProducts();
        }
    }
}