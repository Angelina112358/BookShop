using BookShop.Database;
using BookShop.Domain.Models;
using BookShop.Infrastructure.Interfaces;
using BookShop.Infrastructure.Requests.User;
using BookShop.Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace BookShop.Infrastructure.Services
{
    public class AccountService: IAccountService
    {
        //private readonly AppDbContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenService _tokenService;
        private readonly UserManager<User> _userManager;

        public AccountService(UserManager<User> userManager, TokenService tokenService, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        public async Task<UserRequest> Register(RegisterRequest request)
        {
            if (await UserExists(request.Username))
                throw new UnauthorizedAccessException("Email is already use");

            var user = new User()
            {
                Username = request.Username.ToLower(),
                BirthDate = request.BirthDate,
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                throw new ApplicationException(result.Errors.ToString());

            var roleResult = await _userManager.AddToRoleAsync(user, "Customer");

            if (!roleResult.Succeeded)
                throw new ApplicationException(result.Errors.ToString());

            return new UserRequest()
            {
                Id = user.Id,
                Username = request.Username,
                BirthDate = request.BirthDate,
                PasswordHash = await _tokenService.CreateToken(user),
            };
        }

        public async Task<UserRequest> Login(LoginRequest request)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(x => x.Username.Equals(request.Username.ToLower()));

            if (user == null)
                throw new UnauthorizedAccessException("Username doesn't exist");

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
                throw new UnauthorizedAccessException();

            return new UserRequest()
            {
                Id = user.Id,
                Username = request.Username,
                PasswordHash = await _tokenService.CreateToken(user),
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.Username.Equals(username.ToLower()));
        }
    }
}
