using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Dtos.Token;
using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Service
{
    public interface IAutenticacaoService
    {
        Task<TokenResponseDto> LogarUsuario(LogarUsuarioDto loginDto);

    }
}