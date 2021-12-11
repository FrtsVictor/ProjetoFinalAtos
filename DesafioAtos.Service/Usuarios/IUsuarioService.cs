using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Service.Usuarios
{
    public interface IUsuarioService
    {
        Task Atualizar(AtualizarUsuarioDto atualizarUsuarioDto);
        Task Remover(long id);
        Task<Usuario> CriarConta(CriarUsuarioDto criarUsuarioDto);
    }
}
