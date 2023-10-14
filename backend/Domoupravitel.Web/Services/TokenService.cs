using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domoupravitel.Models;
using Microsoft.IdentityModel.Tokens;

namespace Domoupravitel.Web.Services
{
    public class TokenService
    {
        private const int ExpirationMinutes = 60;

        public string CreateToken(User user)
        {
            var expiration = DateTime.Now.AddMinutes(ExpirationMinutes);
            var token = CreateJwtToken(this.CreateClaims(user), this.CreateSigningCredentials(), expiration);
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        private JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials, DateTime expiration) =>
            new("domoupravitel", "domoupravitel", claims, expires: expiration, signingCredentials: credentials);

        private List<Claim> CreateClaims(User user)
        {
            try
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, "TokenForTheDomoupravitelApp"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, ((int)user.Role).ToString()),
                };
                return claims;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private SigningCredentials CreateSigningCredentials()
        {
            return new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("0e9234e9fc4ee2f043f824c45ef5329c8d502057028bba8d78746586e2905c57")),
                SecurityAlgorithms.HmacSha256);
        }
    }
}
