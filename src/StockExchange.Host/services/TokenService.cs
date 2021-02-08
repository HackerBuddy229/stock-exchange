using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using StockExchange.Host.enums;
using StockExchange.Host.indentity;
using Microsoft.Extensions.Configuration;

namespace StockExchange.Host.services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public string CreateToken(TokenType tokenType, ApplicationIdentityUser user)
        {
            var credentials = CreateSigningCredentials(tokenType);
            var claims = SetClaims(user, tokenType);
            var expiry = GetExpiry(tokenType);

            var jwtSecurityTokenSpecification = new JwtSecurityToken(
                issuer: _configuration["jwt:issuer"],
                audience: _configuration["jwt:audience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiry,
                signingCredentials: credentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityTokenSpecification);
            return token;
        }

        private DateTime GetExpiry(TokenType tokenType)
        {
            var expiry = tokenType switch
            {
                TokenType.Authentication => DateTime.UtcNow.AddHours(_configuration.GetValue<int>("jwt:authExpiry")),
                TokenType.Refresh => DateTime.UtcNow.AddHours(_configuration.GetValue<int>("jwt:refreshExpiry")),
                _ => throw new ArgumentException()
            };
            return expiry;
        }

        private IList<Claim> SetClaims(ApplicationIdentityUser user, TokenType tokenType)
        {
            throw new NotImplementedException();
        }

        private SigningCredentials CreateSigningCredentials(TokenType tokenType)
        {
            var key = tokenType switch
            {
                TokenType.Authentication => GetAuthenticationKey(),
                TokenType.Refresh => GetRefreshKey(),
                _ => throw new ArgumentException()
            };
            
            const string algorithm = SecurityAlgorithms.HmacSha256;
            var credentials = new SigningCredentials(key, algorithm);
            
            return credentials;
        }
        
        private SymmetricSecurityKey GetAuthenticationKey()
        {
            var secret = _configuration["jwt:authenticationSecret"];
            var bytes = Encoding.UTF8.GetBytes(secret);
            var key = new SymmetricSecurityKey(bytes);

            return key;
        }
        
        private SymmetricSecurityKey GetRefreshKey()
        {
            var secret = _configuration["jwt:refreshSecret"];
            var bytes = Encoding.UTF8.GetBytes(secret);
            var key = new SymmetricSecurityKey(bytes);

            return key;
        }
    }
}