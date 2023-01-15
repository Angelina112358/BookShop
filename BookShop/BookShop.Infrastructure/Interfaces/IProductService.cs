using BookShop.Infrastructure.Responses;
using BookShop.Infrastructure.Requests.Product;

namespace BookShop.Infrastructure.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProductsAsync();
        Task<ProductViewModel> GetProductByIdAsync(int id);
        Task<ProductViewModel> GetProductByNameAsync(string name);
        Task CreateProductAsync(CreateProductRequest product);
        Task UpdateProductAsync(int id, UpdateProductRequest product);
        Task DeleteProductAsync(int id);
    }
}
