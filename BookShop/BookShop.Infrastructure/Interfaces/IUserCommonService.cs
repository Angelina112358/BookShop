using BookShop.Domain.Models;

namespace BookShop.Infrastructure.Interfaces
{
    public interface IUserCommonService
    {
        public Task CreateUserAsync(User user);
        public Task<User> GetUserByIdAsync(int id);
        public Task<User> GetUserByNameAsync(string username);
    }
}
