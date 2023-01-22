using BookShop.Database;
using BookShop.Domain.Models;
using BookShop.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Services
{
    public class UserCommonService : IUserCommonService
    {
        private readonly AppDbContext _context;
        public UserCommonService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateUserAsync(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<User> GetUserByNameAsync(string username)
        {
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Username == username);
            return user;
        }
    }
}
