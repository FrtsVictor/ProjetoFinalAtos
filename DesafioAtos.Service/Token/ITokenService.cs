using DesafioAtos.Domain.Dtos.Token;

public interface ITokenService
{
    TokenResponseDto CriarToken(CreateTokenDto createTokenDto);
}