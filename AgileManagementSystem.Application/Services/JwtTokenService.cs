using AgileManagementSystem.Application.Dtos;
using AgileManagementSystem.Core.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Application.Services
{
    public class JwtTokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
       
        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Json Web Token Library kullanılacak. JWT ile token oluşturacağız.Auth 2.0 (Open Authorization 2.0) ve ODIC (Open Id Connect Protokol)
        /// </summary>
        /// <param name="Claims"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<TokenDto> GenerateToken(IEnumerable<Claim> Claims)
        {
            // Kullanıcı ile alakalı bilgilerin üzerinde tutulduğu nesne => ClaimType ve ClaimValue olarak key-value pair şeklinde tutulur.
            var token = new JwtSecurityToken
                (
                    issuer: _configuration["JWT:issuer"],
                    audience: _configuration["JWT:audience"],
                    claims: Claims,
                    expires: DateTime.UtcNow.AddSeconds(TokenExpireDateHelper.GetExpireDateSeconds),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:signingKey"])), SecurityAlgorithms.HmacSha512)
                );

            var model = new TokenDto
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = TokenHelper.GetRefreshToken()
            };

            return await Task.FromResult(model);
        }
    }
}
