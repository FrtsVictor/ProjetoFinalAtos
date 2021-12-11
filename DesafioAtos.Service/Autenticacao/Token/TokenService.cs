using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DesafioAtos.Domain.Dtos.Token;
using DesafioAtos.Domain.Entidades;
using DesafioAtos.Service.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

public class TokenService : ITokenService
{
    private readonly string _tokenKey;
    private readonly ILogger<TokenService> _logger;
    public TokenService(IConfiguration configuration, ILogger<TokenService> logger)
    {
        this._tokenKey = configuration["jwtKey"];
        this._logger = logger;
    }

    public TokenResponseDto CriarToken(CreateTokenDto criacaoTokenDto)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenKey);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, criacaoTokenDto.Identificador),
                    new Claim("Id", criacaoTokenDto.Id.ToString()),
                    new Claim(ClaimTypes.Role, criacaoTokenDto.Role)
                }),

                Expires = DateTime.UtcNow.AddHours(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), algorithm: SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string userToken = tokenHandler.WriteToken(token);

            return new TokenResponseDto() { Token = userToken };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw new TokenGenerationException("Error creating token", ex);
        }
        
    }
}