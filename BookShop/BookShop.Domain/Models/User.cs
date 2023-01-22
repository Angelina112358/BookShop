namespace BookShop.Domain.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Username { get; set; }
        public DateTime BirthDate { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? LockoutDate { get; set; }
        public Role RoleId { get; set; }
        public Role Role { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
