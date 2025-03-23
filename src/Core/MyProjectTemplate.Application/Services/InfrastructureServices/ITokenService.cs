using System.Security.Claims;

namespace MyProjectTemplate.Application.Services.InfrastructureServices;

public interface ITokenService
{
    string CreateAccessToken(List<Claim> claims = null);
    string CreateRefreshToken();
}