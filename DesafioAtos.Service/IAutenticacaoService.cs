using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Service
{
    public interface IAutenticacaoService
    {
        Task<Usuario> Logar(CriarUsuarioDto createUserDto);
        Task<Usuario> CriarConta(CriarUsuarioDto createUserDto);
    }
}