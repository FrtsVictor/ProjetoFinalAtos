using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Dtos.Token;

namespace DesafioAtos.Service.Services.Autenticacao
{
    public interface IAutenticacaoService
    {
        Task<TokenResponseDto> LogarUsuario(LogarUsuarioDto loginDto);
    }
}