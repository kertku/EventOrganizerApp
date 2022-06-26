using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Extensions.Base
{
    public static class IdentityExtensions
    {
        public static Guid? GetUserId(this ClaimsPrincipal user)
        {
            var claim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (claim != null) return Guid.Parse(claim.Value);

            return null;
        }

        public static string GenerateJwt(IEnumerable<Claim> claims, string key, string issuer, string audience,
            DateTime expirationDateTime)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: expirationDateTime,
                signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}