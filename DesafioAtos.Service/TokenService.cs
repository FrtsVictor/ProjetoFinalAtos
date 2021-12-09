using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DesafioAtos.Domain.Entidades;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

public class TokenService : ITokenService
{
    private readonly string _tokenKey;
    public TokenService(IConfiguration configuration)
    {
        _tokenKey = configuration["jwtKey"];
    }

    public string GenerateToken(Usuario user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_tokenKey);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Name, user?.Login)
            }),

            Expires = DateTime.UtcNow.AddHours(1),

            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                algorithm: SecurityAlgorithms.HmacSha256Signature)
        };

        //foreach (var role in user.Roles)
        //{
        //    tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role.Name));
        //}

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}