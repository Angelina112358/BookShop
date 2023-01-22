using BookShop.Infrastructure.Requests.User;
using BookShop.Infrastructure.Responses;

namespace BookShop.Infrastructure.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticationResponse> RegisterAsync(RegisterRequest model, int roleId);
        //Task<AuthenticationResponse> LoginAsync(LoginRequest model);
        //Task<User> GetMeAsync(ClaimsPrincipal claimsPrincipal);
    }
}
