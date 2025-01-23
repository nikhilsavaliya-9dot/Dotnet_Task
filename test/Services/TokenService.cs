using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using test.Helpers;

namespace test.Services
{
    public class TokenService
    {
        private readonly JwtConfig _jwtConfig;
        public TokenService(IOptions<JwtConfig> jwtSettings)
        {
            this._jwtConfig = jwtSettings.Value; // Get the config values
        }

        public string? GenerateToken(int UserId, string? RoleName, string? email)
        {
            // Define the security key and signing credentials
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Create a list of claims instead of an array
            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, RoleName?? string.Empty),
                    new Claim(JwtRegisteredClaimNames.Email, email),
                    new Claim("Id", UserId.ToString())
                };

            

            // Create the token
            var token = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,
                audience: _jwtConfig.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(_jwtConfig.AccessTokenExpiration),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
