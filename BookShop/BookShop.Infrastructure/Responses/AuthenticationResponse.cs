namespace BookShop.Infrastructure.Responses
{
    public class AuthenticationResponse
    {
        public bool IsSuccess { get; set; } = true;

        public int UserId { get; set; }

        public string AccessToken { get; set; }
    }
}
