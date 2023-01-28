using BookShop.Domain.Models;
using BookShop.Infrastructure.Requests.User;
using BookShop.Infrastructure.Responses;
using System.Security.Claims;

namespace BookShop.Infrastructure.Interfaces
{
    public interface IAccountService
    {
        Task<UserRequest> Register(RegisterRequest request);
        Task<UserRequest> Login(LoginRequest request);
    }
}
