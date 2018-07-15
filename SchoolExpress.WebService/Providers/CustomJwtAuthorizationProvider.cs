using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.Providers
{
    public class CustomJwtAuthorizationProvider
    {
        public static string Issuer { get; set; }

        public static string Audience { get; set; }

        public CustomJwtAuthorizationProvider()
        {
            Issuer = "self";
            Audience = "http://www.example.com";
        }

        public CustomJwtAuthorizationProvider(string issuer, string audience)
        {
            Issuer = issuer;
            Audience = audience;
        }

        public string GenerateToken(string secretKey, string userId, string userName, IEnumerable<string> roles,
            double expiration)
        {
            ClaimsIdentity identity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, userName),
                new Claim("sub", userName)
            }, "Bearer");

            foreach (string role in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            return CreateToken(secretKey, identity, expiration);
        }

        public ClaimsPrincipal GetPrincipal(string secretKey, string token)
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
                IssuerSigningKey = signingKey,
                RequireExpirationTime = true
            };
          
            SecurityToken securityToken;
            JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
            ClaimsPrincipal principal = securityTokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken); 
            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;          
            if (jwtSecurityToken != null)
            {
                DateTime validTo = jwtSecurityToken.ValidTo;
                if (validTo < DateTime.UtcNow)
                {
                    throw new SecurityTokenExpiredException();
                }
            }

            return principal;
        }

        public string CreateToken(string secretKey, ClaimsIdentity identity, double expiration)
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
                Expires = DateTime.UtcNow.AddMinutes(expiration),
                NotBefore = DateTime.UtcNow
            };

            JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = securityTokenHandler.CreateToken(securityTokenDescriptor);
            return securityTokenHandler.WriteToken(securityToken);
        }
    }
}