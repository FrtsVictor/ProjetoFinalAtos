using DesafioAtos.Domain.Dtos;

namespace DesafioAtos.Service.Usuarios
{
    public interface IUsuarioService
    {
        Task Atualizar(AtualizarUsuarioDto atualizarUsuarioDto);
        Task Remover(long id);
    }
}
