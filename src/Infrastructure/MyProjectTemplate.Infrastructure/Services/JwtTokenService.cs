using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyProjectTemplate.Application.Services.InfrastructureServices;
using MyProjectTemplate.Infrastructure.Configurations;

namespace MyProjectTemplate.Infrastructure.Services;

public class JwtTokenService(IOptions<JwtSettings> jwtSettings) : ITokenService
{
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;

    public string CreateAccessToken(List<Claim> claims = null)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, claims,expires: DateTime.Now.AddMinutes(_jwtSettings.TokenValidityMinute), signingCredentials: credentials);
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string CreateRefreshToken()
    {
        using var rng = RandomNumberGenerator.Create();
        var byteArray = new byte[64];
        rng.GetBytes(byteArray);
        return Convert.ToBase64String(byteArray).Replace("+", "").Replace("/", "").Replace("=", "");
    }
}