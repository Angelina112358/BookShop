using BookShop.Infrastructure.Requests.User;
using BookShop.Infrastructure.Responses;

namespace BookShop.Infrastructure.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticationResponse> RegisterAsync(RegisterOrLoginRequest request, int roleId);
        Task<AuthenticationResponse> LoginAsync(RegisterOrLoginRequest request);
        //Task<User> GetMeAsync(ClaimsPrincipal claimsPrincipal);
    }
}
