using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.Filters
{
    public static class JwtAuthenticationModule
    {
        public static string GenerateToken(string secretKey, string userId, string username, IEnumerable<string> roles, double expiration)
        {
            string sha = SHA.GenerateSHA256(secretKey);
            byte[] symmetricKey = Convert.FromBase64String(sha);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            
            IList<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, username)               
            };

            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);
            return token;
        }

        public static ClaimsPrincipal GetPrincipal(string secretKey, string token)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            if (jwtToken == null)
                return null;

            string sha = SHA.GenerateSHA256(secretKey);
            byte[] symmetricKey = Convert.FromBase64String(sha);

            TokenValidationParameters validationParameters = new TokenValidationParameters
            {
                RequireExpirationTime = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
            };

            return tokenHandler.ValidateToken(token, validationParameters, out _);
        }
    }
}