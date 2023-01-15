namespace BookShop.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
        public OrderState State { get; set; }
        public enum OrderState
        {
            Packed,
            Ready
        }
    }
}
