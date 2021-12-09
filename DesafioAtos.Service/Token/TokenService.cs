using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DesafioAtos.Domain.Dtos.Token;
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

    public TokenResponseDto CriarToken(CreateTokenDto criacaoTokenDto)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_tokenKey);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Name, criacaoTokenDto.Identificador),
                    new Claim("Id", criacaoTokenDto.Id.ToString())
            }),

            Expires = DateTime.UtcNow.AddHours(1),

            SigningCredentials = new SigningCredentials( new SymmetricSecurityKey(key), algorithm: SecurityAlgorithms.HmacSha256Signature)
        };

        tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role,criacaoTokenDto.Role));
        var token = tokenHandler.CreateToken(tokenDescriptor);
        string userToken = tokenHandler.WriteToken(token);

        return new TokenResponseDto() { Token = userToken };
    }
}