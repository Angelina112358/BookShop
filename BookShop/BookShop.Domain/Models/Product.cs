using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public List<Category> Categories { get; set; } = new();
        public Photo? Photo;
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
}
