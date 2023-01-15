using BookShop.Infrastructure.Requests.Category;
using BookShop.Infrastructure.Responses;

namespace BookShop.Infrastructure.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllCategoriesAsync();
        Task<CategoryViewModel> GetCategoryByIdAsync(int id);
        Task<CategoryViewModel> GetCategoryByNameAsync(string name);
        Task CreateCategoryAsync(CreateCategoryRequest request);
        Task UpdateCategoryAsync(int id, UpdateCategoryRequest request);
        Task DeleteCategoryAsync(int id);
    }
}
