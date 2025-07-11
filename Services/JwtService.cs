using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CatalogoDeDoces.Dtos;
using CatalogoDeDoces.Models; // <- necessário para acessar UsuarioModel
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

        public string GerarToken(UsuarioModel usuario)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettingDto.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.UsuarioId.ToString()),
                new Claim(ClaimTypes.Role, usuario.EhAdministrador ? "admin" : "user"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioId.ToString()),
                new Claim(ClaimTypes.Name, usuario.NomeUsuario), // aparecerá como User.Identity.Name
                new Claim("EhAdministrador", usuario.EhAdministrador.ToString().ToLower()) // usado nas Views Razor
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
