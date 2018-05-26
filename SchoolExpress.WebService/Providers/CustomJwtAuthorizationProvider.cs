using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.Providers
{
    public static class CustomJwtAuthorizationProvider
    {
        public static string Issuer { get; set; }

        public static string Audience { get; set; }

        static CustomJwtAuthorizationProvider()
        {
            Issuer = "self";
            Audience = "http://www.example.com";
        }

        public static string GenerateToken(string secretKey, string userId, string userName, IEnumerable<string> roles,
            double expiration)
        {
            ClaimsIdentity identity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, userName)
            }, "Bearer");

            foreach (string role in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            return CreateToken(secretKey, identity, expiration);
        }

        public static ClaimsPrincipal GetPrincipal(string secretKey, string token)
        {
            string sha = SHA.GenerateSHA256(secretKey);
            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(sha));
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidAudiences = new[]
                {
                    Audience
                },

                ValidIssuers = new[]
                {
                    Issuer
                },
                IssuerSigningKey = signingKey
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
            return principal;
        }

        private static string CreateToken(string secretKey, ClaimsIdentity identity, double expiration)
        {
            string sha = SHA.GenerateSHA256(secretKey);
            SecurityKey signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(sha));
            SigningCredentials signingCredentials = new SigningCredentials(signingKey,
                SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = Audience,
                Issuer = Issuer,
                Subject = identity,
                SigningCredentials = signingCredentials,
                Expires = DateTime.UtcNow.AddMinutes(expiration)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
            return tokenHandler.WriteToken(plainToken);
        }
    }
}