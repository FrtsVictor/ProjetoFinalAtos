using DesafioAtos.Domain.Dtos.Token;
using DesafioAtos.Service.Fabrica.Services;

namespace DesafioAtos.Service.Services.Token
{
    public interface ITokenService
    {
        TokenResponseDto CriarToken(CreateTokenDto createTokenDto);
    }
}

