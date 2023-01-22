using BookShop.Domain.Models;
using System.Security.Claims;

namespace BookShop.Infrastructure.Interfaces
{
    public interface IUserClaimsFactory
    {
        Task<List<Claim>> GetClaimsAsync(User user);
    }
}
