using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShop.Database;
using BookShop.Domain.Models;
using BookShop.Infrastructure.Interfaces;
using BookShop.Infrastructure.Requests.Category;
using BookShop.Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        private IQueryable<CategoryViewModel> GetQueryable() =>
            _context
                .Categories
                .ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider);

        public async Task CreateCategoryAsync(CreateCategoryRequest request)
        {
            var category = _mapper.Map<CreateCategoryRequest, Category>(request);
            _context.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var categoryToDelete = await _context
                .Categories
                .FirstOrDefaultAsync(
                    c => c.Id == id);

            _context.Remove(categoryToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryViewModel>> GetAllCategoriesAsync() =>
            await GetQueryable().ToListAsync();

        public async Task<CategoryViewModel> GetCategoryByIdAsync(int id) =>
            await GetQueryable().FirstOrDefaultAsync(category => category.Id == id);
        public async Task<CategoryViewModel> GetCategoryByNameAsync(string name) =>
            await GetQueryable().FirstOrDefaultAsync(category => category.Name == name);
        public async Task UpdateCategoryAsync(int id, UpdateCategoryRequest request)
        {
            var categoryToUpdate = await _context
                .Categories
                .FirstOrDefaultAsync(
                    c => c.Id == id);
            _mapper.Map(request, categoryToUpdate);
            _context.Update(categoryToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
