using BookShop.Domain.Models;
using BookShop.Infrastructure.Requests.Order;
using BookShop.Infrastructure.Responses;

namespace BookShop.Infrastructure.Interfaces
{
    public interface IOrderService
    {
        public Task CreateOrderAsync(int userId, CreateOrderRequest request);
        public Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync();
        //public Task<IEnumerable<ProductOrder>> GetAll();
        //public Task CreateProductOrder(ProductOrderRequest request);
    }
}
