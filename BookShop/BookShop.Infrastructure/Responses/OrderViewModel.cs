namespace BookShop.Infrastructure.Responses
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Address { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
        public decimal TotalPrice { get; set; }
        public UserViewModel User { get; set; }
        public class UserViewModel
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public DateTime BirthDate { get; set; }
            public int RoleId { get; set; }
            public string Role { get; set; }
            public DateTime? LockoutDate { get; set; }
        }
    }
}
