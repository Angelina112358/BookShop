using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShop.Infrastructure.Interfaces;
using BookShop.Database;
using BookShop.Infrastructure.Responses;
using BookShop.Infrastructure.Requests.Product;
using BookShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Services
{
    public class ProductService: IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        
        public ProductService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        private IQueryable<ProductViewModel> GetQueryable() =>
            _context
                .Products
                .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);
        
        public async Task CreateProductAsync(CreateProductRequest request)
        {
            var product = _mapper.Map<CreateProductRequest, Product>(request);
            await UpdateCategories(request, product);
            _context.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(product => product.Id == id);

            _context.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductViewModel> GetProductByIdAsync(int id)
        {
            var product = await GetQueryable()
               .FirstOrDefaultAsync(product => product.Id == id);

            return product;
        }

        public async Task<ProductViewModel> GetProductByNameAsync(string name)
        {
            var product = await GetQueryable()
               .FirstOrDefaultAsync(product => product.Name == name);

            return product;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync() =>
            await GetQueryable().ToListAsync();

        public async Task UpdateProductAsync(int id, UpdateProductRequest request)
        {
            var product = await _context
                .Products
                .Include(product => product.Categories)
                .FirstOrDefaultAsync(product => product.Id == id);

            _mapper.Map(request, product);
            _context.Update(product);
            await UpdateCategories(request, product);
            await _context.SaveChangesAsync();
        }
        
        private async Task UpdateCategories(ProductRequest request, Product product)
        {
            var categoryIds = request.CategoryIds.ToHashSet();
            var categories = await _context
                .Categories
                .Where(category => categoryIds.Contains(category.Id))
                .ToListAsync();

            product.Categories.Clear();
            product.Categories.AddRange(categories);
        }
    }
}
