using BookShop.Infrastructure.Responses;
using BookShop.Infrastructure.Requests.Product;

namespace BookShop.Infrastructure.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProductsAsync();
        Task<ProductViewModel> GetProductByIdAsync(Guid id);
        Task<ProductViewModel> GetProductByNameAsync(string name);
        Task CreateProductAsync(CreateProductRequest product);
        Task UpdateProductAsync(Guid id, UpdateProductRequest product);
        Task DeleteProductAsync(Guid id);
    }
}
