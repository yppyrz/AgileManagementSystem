using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Core.Helpers
{
    /// <summary>
    /// Access Token Expire olduğunda üretilecek olan string base64 formatında refresh token. Token oluşturulurken User'ın hesabında refresh token bilgisini saklarız ve access token expire olduğunda gidip bu refresh token kontrolü yapıp bir access token üretilmesini sağlarız.
    /// </summary>
    public static class TokenHelper
    {
        public static string GetRefreshToken()
        {
            var randomNumber = new byte[32];
            string token = "";

            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomNumber);
                token = Convert.ToBase64String(randomNumber);
            }
            return token;
        }

        public static ClaimsPrincipal ValidateAccessToken(string accessToken)
        {
            // Kullanıcı expire olduğundan, ValidateLifeTime false olarak ayarlandı.
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("x-secret-key-x-secret-key")),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);

            return principal;
        }
    }
}
