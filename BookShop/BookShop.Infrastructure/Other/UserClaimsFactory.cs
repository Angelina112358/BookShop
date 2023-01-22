using BookShop.Domain.Models;
using BookShop.Infrastructure.Interfaces;
using System.Security.Claims;

namespace BookShop.Infrastructure.Other
{
    public class UserClaimsFactory: IUserClaimsFactory
    {
        public Task<List<Claim>> GetClaimsAsync(User user)
        {
            var role = user.Role.Name;
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.Username),
                new(ClaimTypes.Role, role),
                new(ClaimTypes.Role, user.RoleId.ToString())
            };
            return Task.FromResult(claims);
        }
    }
}
