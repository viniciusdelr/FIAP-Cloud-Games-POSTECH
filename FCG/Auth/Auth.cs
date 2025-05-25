using JWT_Example;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FCG.Auth
{
    public class Auth
    {
        private readonly JwtSettings _jwtSettings;

        public Auth(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public string GerarAuth()
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "testuser"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpiryMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
