using SqlApp21.Models;

namespace SqlApp21.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}