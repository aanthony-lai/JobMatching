using JobMatching.Infrastructure.DataAccess;
using JobMatching.Infrastructure.DataAccess.Entities;
using JobMatching.Infrastructure.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JobMatching.Infrastructure.DependencyInjection;

public static class AuthenticationDependencyHandler
{
    public static WebApplicationBuilder RegisterAuthenticationConfigurations(
        this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentityCore<UserEntity>()
                .AddEntityFrameworkStores<AppDbContext>();

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettingsReader.GetValue("Jwt:Secret"))),
                    ValidIssuer = AppSettingsReader.GetValue("Jwt:Issuer"),
                    ValidAudience = AppSettingsReader.GetValue("Jwt:Audience"),
                    ClockSkew = TimeSpan.Zero
                };

            });
        builder.Services.AddAuthorization();

        return builder;
    }
}