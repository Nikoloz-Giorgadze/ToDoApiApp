using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoApi.Domain.Users;

namespace ToDoApi.Infrastructure.Auth;

public static class JwtHealper
{
    public static string CreateToken(User user, IConfiguration configuration)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var secretKey = configuration.GetValue<string>("JWTConfiguration:SecretKey");
        var key = Encoding.UTF8.GetBytes(secretKey);

        var tokenDescription = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            }),
            Expires = DateTime.Now.AddDays(1),
            Audience = "localhost",
            Issuer = "localhost",
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)
        };
        var token = tokenHandler.CreateToken(tokenDescription);
        return tokenHandler.WriteToken(token);
    }
}
