using DesafioAtos.Domain.Dtos.Usuario;
using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Service.Usuarios
{
    public interface IUsuarioService
    {
        Task Atualizar(AtualizarUsuarioDto atualizarUsuarioDto);
        Task Remover(long id);
    }
}
