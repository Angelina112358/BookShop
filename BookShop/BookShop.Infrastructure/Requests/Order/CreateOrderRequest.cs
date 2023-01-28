using BookShop.Infrastructure.Requests.Product;
using static BookShop.Domain.Models.Order;

namespace BookShop.Infrastructure.Requests.Order
{
    public class CreateOrderRequest
    {
        public int OrderId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Address { get; set; }
        public IEnumerable<ProductOrderRequest> Products { get; set; }
        public OrderState State { get; set; }
    }
}
