namespace BookShop.Infrastructure.Requests.User
{
    public class TokenIssuerOptions
    {
        public const string Section = "TokenIssuerOptions";
        public string Secret { get; set; }
    }
}
