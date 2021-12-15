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
        Task<IEnumerable<string>> ObterCategorias(int idUsuario);
        Task<IEnumerable<CategoriaEmpresa>> ObterEmpresasPorCategoriaUsuario(int idUsuario);
    }
}
