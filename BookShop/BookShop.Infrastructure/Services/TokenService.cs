using BookShop.Domain.Models;
using BookShop.Infrastructure.Interfaces;
using BookShop.Infrastructure.Responses;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using BookShop.Infrastructure.Requests.User;

namespace BookShop.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IOptions<TokenIssuerOptions> _optionsHandler;
        private readonly IUserClaimsFactory _factory;

        public TokenService(IOptions<TokenIssuerOptions> optionsHandler, IUserClaimsFactory factory)
        {
            _optionsHandler = optionsHandler;
            _factory = factory;
        }

        public async Task<AuthenticationResponse> CreateAuthenticationResponseAsync(User user)
        {
            var options = _optionsHandler.Value;
            var tokenDescriptor = new JwtSecurityToken(
                issuer: "http://localhost:5000",
                audience: "http://localhost:5000",
                notBefore: DateTime.UtcNow,
                claims: new ClaimsIdentity(await _factory.GetClaimsAsync(user), JwtBearerDefaults.AuthenticationScheme).Claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(7)),
                signingCredentials: new(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(options.Secret)), SecurityAlgorithms.HmacSha256));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
            return new() { AccessToken = accessToken, UserId = user.Id };
        }
    }
}
