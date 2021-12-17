using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entidades;
using DesafioAtos.Domain.Enums;
using DesafioAtos.Service.Services;

namespace DesafioAtos.Service.Services.Usuarios
{
    public interface IUsuarioService : IBaseService
    {
        Task<UsuarioDto> ObterUsuario(int id);
        Task Editar(int idUsuario, EditarUsuarioDto atualizarUsuarioDto);
        Task Remover(int id);
        Task<Usuario> CriarUsuario(CriarUsuarioDto criarUsuarioDto);
        Task<ECategoria> AdicionarCategoria(CategoriaDto categoriaDto);
        Task RemoverCategoria(CategoriaDto categoriaDto);
        Task<IEnumerable<string>?> ObterCategorias(int idUsuario);
        Task<IEnumerable<EmpresaColetoraDto>?> ObterEmpresasPorCategoriaUsuario(int idUsuario);
    }
}