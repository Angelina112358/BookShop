using BookShop.Domain.Models;
using BookShop.Infrastructure.Responses;

namespace BookShop.Infrastructure.Interfaces
{
    public interface ITokenService
    {
        public Task<string> CreateToken(User user);
    }
}
