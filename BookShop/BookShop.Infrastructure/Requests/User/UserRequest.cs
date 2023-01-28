namespace BookShop.Infrastructure.Requests.User
{
    public class UserRequest
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime BirthDate { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? LockoutDate { get; set; }
    }
}
