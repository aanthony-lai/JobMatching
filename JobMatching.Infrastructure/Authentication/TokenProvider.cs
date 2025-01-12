using JobMatching.Infrastructure.Utilities;
using JobMatching.Domain.Authentication;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using JobMatching.Domain.Entities.User;

namespace JobMatching.Infrastructure.Authentication;

public sealed class TokenProvider : ITokenProvider
{
    public string Create(DomainUser user)
    {
        string secretKey = AppSettingsReader.GetValue("Jwt:Secret");
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Name.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.Name.LastName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("accountType", user.UserType.ToString())
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