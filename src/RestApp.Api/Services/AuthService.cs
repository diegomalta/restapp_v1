using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using restapp.Domain.Security;
using RestApp.Domain.Model;
using RestApp.Domain.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestApp.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<RestAppUser> _signInManager;
        private readonly UserManager<RestAppUser> _userManager;
        private readonly IConfiguration _config;

        public AuthService(SignInManager<RestAppUser> signInManager, UserManager<RestAppUser> userManager, IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
        }

        public async Task<TokenResult> GenerateToken(TokenRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

                if (result.Succeeded)
                {
                    var claims = new[]
                    {
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Website, user.DataBaseName)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        _config["Token:Issuer"],
                        _config["Token:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(30),
                        signingCredentials: creds
                    );

                    return new TokenResult
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo,
                        IsSuccess = true
                    };
                    
                }
            }

            return new TokenResult { IsSuccess = false, Message = "Incorrect User or Password" };
        }
    }
}
