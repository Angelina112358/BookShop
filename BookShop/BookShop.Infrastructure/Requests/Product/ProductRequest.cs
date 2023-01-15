namespace BookShop.Infrastructure.Requests.Product
{
    public class ProductRequest
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<int> CategoryIds { get; set; } = new();
    }
}
