using DesafioAtos.Domain.Dtos.Token;

namespace DesafioAtos.Service.Services.Token
{
    public interface ITokenService
    {
        TokenResponseDto CriarToken(CreateTokenDto createTokenDto);
    }
}