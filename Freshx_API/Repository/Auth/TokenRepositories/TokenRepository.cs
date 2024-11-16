﻿using Freshx_API.Dtos.Auth.Account;
using Freshx_API.Interfaces.Auth;
using Freshx_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Freshx_API.Repository.Auth.TokenRepositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        private readonly SymmetricSecurityKey _key;
        public TokenRepository(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        }

        public async Task<TokenInfo> IssueAccessToken(AppUser app)
        {
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                // 1. Custom Claims - Tự định nghĩa
                new Claim("App_Id",app.Id),           
                // 2.Claimd chuan ClaimType
                new Claim(ClaimTypes.NameIdentifier,app.Id),
                new Claim(ClaimTypes.Name,app.UserName),
                new Claim(ClaimTypes.Email,app.Email),
                // 3.Claims chuẩn từ JwtRegisteredClaimNames
                // 3. Claims chuẩn từ JwtRegisteredClaimNames
                new Claim(JwtRegisteredClaimNames.Sub, app.Id),     // Subject (ID)
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // JWT ID
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)// Issued At
            };
            var roles = await _userManager.GetRolesAsync(app);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var expireAt = DateTime.UtcNow.AddHours(1);
            var token = new JwtSecurityToken(
            //  issuer: _configuration["Jwt:Issuer"],
            //  audience: _configuration["Jwt:Audience"],
              claims: claims,
              expires: DateTime.UtcNow.AddHours(1),
              signingCredentials: credentials
              );
            return new TokenInfo
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresAt = expireAt               
            };              
        }

        public string IssueRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public async Task<bool> SaveRefreshToken(string userName, string refreshToken)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return false;
            }
            user.RefreshToken = refreshToken;
            user.ExpiredTime = DateTime.UtcNow.AddDays(7);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded) { return true; }
            return false;
        }
        public async Task<string?> RetrieveUsernameByRefreshToken(string refreshToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken && u.ExpiredTime > DateTime.UtcNow);
            return user?.UserName;
        }
    }
}
