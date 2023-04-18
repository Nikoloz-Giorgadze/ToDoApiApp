using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ToDoApi.Infrastructure.Extensions;

public static class AuthExtension
{
    public static IServiceCollection AddTokenAuthentications(this IServiceCollection services, IConfiguration option)
    {
        var secretKey = option.GetValue<string>("JWTConfiguration:SecretKey");
        var key = Encoding.UTF8.GetBytes(secretKey);
        services.AddAuthentication(
            x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            x.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = "localhost",
                ValidAudience = "localhost",
            });
        return services;
    }
}
