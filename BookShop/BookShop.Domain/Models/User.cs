namespace BookShop.Domain.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Username { get; set; }
        public DateTime BirthDate { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public List<Role> Roles { get; set; }
        public DateTime? LockoutDate { get; set; }
        public List<Order> Orders { get; set; } = new();
    }
}
