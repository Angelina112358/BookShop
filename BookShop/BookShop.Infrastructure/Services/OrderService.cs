using AutoMapper;
using BookShop.Database;
using BookShop.Domain.Models;
using BookShop.Infrastructure.Interfaces;
using BookShop.Infrastructure.Requests.Order;

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

        //public async Task<int> CreateOrderAsync(int userId, CreateOrderRequest request)
        //{
        //    if(request == null)
        //        throw new ArgumentNullException(nameof(request), "Can't create empty order");

        //    var products = new List<ProductOrder>();

        //    var order = await _context.Orders.AddAsync(new Order
        //    {
        //        UserId = userId,
        //        CreationDate = DateTime.Now,
        //        ProductOrders = products
        //    });
        //}
    }
}
