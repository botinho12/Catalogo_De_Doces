using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CatalogoDeDoces.Dtos;
using CatalogoDeDoces.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CatalogoDeDoces.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettingDto _jwtSettingDto;

        public JwtService(IOptions<JwtSettingDto> jwtSetting)
        {
            _jwtSettingDto = jwtSetting.Value;
        }

        public string GerarToken(string userId, string userRole)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettingDto.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(ClaimTypes.Role, userRole),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, userId)
            };

            var token = new JwtSecurityToken(
                issuer: _jwtSettingDto.Issuer,
                audience: _jwtSettingDto.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettingDto.ExpirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
