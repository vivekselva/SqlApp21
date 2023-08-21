using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SqlApp21.Models;
using SqlApp21.Services;

namespace SqlApp21.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products;
        private readonly IProductService _productService;

        public IndexModel(IProductService productService) {
            _productService = productService;
        }
        public void OnGet()
        {
            Products = _productService.GetProducts();
        }
    }
}