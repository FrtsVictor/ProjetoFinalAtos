using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entidades;
using DesafioAtos.Domain.Enums;

namespace DesafioAtos.Service.Usuarios
{
    public interface IUsuarioService
    {
        Task Atualizar(AtualizarUsuarioDto atualizarUsuarioDto);
        Task Remover(long id);
        Task<Usuario> CriarConta(CriarUsuarioDto criarUsuarioDto);
        Task<ECategoria> AdicionarCategoria(CategoriaDto categoriaDto);
        Task RemoverCategoria(CategoriaDto categoriaDto);
        Task<List<string>> ObterCategorias(int idUsuario);
    }
}
