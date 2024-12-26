using JobMatching.DataAccess.Utilities;
using JobMatching.Domain.Authentication;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace JobMatching.Infrastructure.Authentication;

public sealed class TokenProvider : ITokenProvider
{
    public string Create(LoginUserModel userModel)
    {
        string secretKey = AppSettingsReader.GetValue("Jwt:Secret");
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(JwtRegisteredClaimNames.Name, userModel.UserName),
            ]),
            Expires = DateTime.UtcNow.AddMinutes(60),
            SigningCredentials = credentials,
            Issuer = AppSettingsReader.GetValue("Jwt:Issuer"),
            Audience = AppSettingsReader.GetValue("Jwt:Audience")
        };

        var handler = new JsonWebTokenHandler();

        return handler.CreateToken(tokenDescriptor);
    }
}