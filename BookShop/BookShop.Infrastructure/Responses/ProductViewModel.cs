namespace BookShop.Infrastructure.Responses
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<CategoryViewModel> Categories { get; set; } = new();
        public string? PhotoUrl { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
}
