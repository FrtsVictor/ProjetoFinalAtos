using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Dtos.Token;
using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Service
{
    public interface IAutenticacaoService
    {
        Task<TokenResponseDto> Logar(LogarUsuarioDto loginDto);
        Task<Usuario> CriarConta(CriarUsuarioDto createUserDto);
    }
}