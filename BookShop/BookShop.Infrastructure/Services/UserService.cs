using BookShop.Database;
using BookShop.Domain.Models;
using BookShop.Infrastructure.Interfaces;
using BookShop.Infrastructure.Requests.User;
using BookShop.Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Services
{
    public class UserService: IUserService
    {
        private readonly AppDbContext _context;
        private readonly UserCommonService _userCommon;
        private readonly TokenService _tokenService;
        public UserService(AppDbContext context, UserCommonService userCommon, TokenService tokenService)
        {
            _context = context;
            _userCommon = userCommon;
            _tokenService = tokenService;
        }

        public async Task<AuthenticationResponse> LoginAsync(RegisterOrLoginRequest request)
        {
            var user = await _userCommon.GetUserByNameAsync(request.Username);
            if (user is null)
                return new() { IsSuccess = false };

            var password = request.Password;
            if (password != user.PasswordHash)
                return new() { IsSuccess = false };
            
            return await _tokenService.CreateAuthenticationResponseAsync(user);
        }

        public async Task<AuthenticationResponse> RegisterAsync(RegisterOrLoginRequest request, int roleId)
        {
            var user = await _userCommon.GetUserByNameAsync(request.Username);
            if (user is null)
                return new() { IsSuccess = false };
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == roleId);
            if (role is null)
                return new() { IsSuccess = false };

            user = new User()
            {
                Username = request.Username,
                RoleId = roleId,
                PasswordHash = request.Password
            };
            await _userCommon.CreateUserAsync(user);
            user = await _userCommon.GetUserByNameAsync(request.Username);
            return await _tokenService.CreateAuthenticationResponseAsync(user);
        }

        
    }
}
