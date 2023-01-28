using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShop.Database;
using BookShop.Domain.Models;
using BookShop.Infrastructure.Interfaces;
using BookShop.Infrastructure.Requests.Order;
using BookShop.Infrastructure.Requests.Product;
using BookShop.Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public OrderService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateOrderAsync(int userId, CreateOrderRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Can't create empty order");

            //var products = request.Products.Select(x => new ProductOrder()).ToList();
            var products = new List<ProductOrder>();

            foreach (var item in request.Products)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id.Equals(item.ProductId));
                if (product == null)
                    throw new ArgumentNullException(nameof(product), "Can't create non-existent product");

                var productOrder = new ProductOrder
                {
                    ProductId = item.ProductId,
                    Product = product,
                    OrderId = request.OrderId,
                };

                products.Add(productOrder);

                await _context.ProductOrders.AddAsync(productOrder);
                await _context.SaveChangesAsync();
            }

            var order = await _context.Orders.AddAsync(new Order()
            {
                UserId = userId,
                ProductOrders = products,
                CreationDate = DateTime.Now,
                Address = request.Address
            });
            await _context.SaveChangesAsync();
        }
        private IQueryable<OrderViewModel> GetQueryable() =>
            _context
                .Orders
                .ProjectTo<OrderViewModel>(_mapper.ConfigurationProvider);
        public async Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync() =>
            await GetQueryable().ToListAsync();        
    }
}
