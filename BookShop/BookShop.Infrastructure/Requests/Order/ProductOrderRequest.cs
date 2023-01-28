namespace BookShop.Infrastructure.Requests.Order
{
    public class ProductOrderRequest
    {
        public int Id { get; set; }
        public int Amount { get; set; } = 1;
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
