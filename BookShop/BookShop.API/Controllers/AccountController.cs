using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookShop.Infrastructure.Requests.User;
using BookShop.Infrastructure.Interfaces;

namespace BookShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService userService)
        {
            _accountService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserRequest>> Register(RegisterRequest request)
        {
            return await _accountService.Register(request);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserRequest>> Login(LoginRequest request)
        {
            return await _accountService.Login(request);
        }
    }
}
