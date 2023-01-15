namespace BookShop.Infrastructure.Requests.Product
{
    public class UpdateProductRequest
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
