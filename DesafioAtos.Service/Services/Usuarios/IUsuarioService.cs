using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entidades;
using DesafioAtos.Domain.Enums;
using DesafioAtos.Service.Services;

namespace DesafioAtos.Service.Services.Usuarios
{
    public interface IUsuarioService : IBaseService
    {
        Task Editar(int idUsuario, EditarUsuarioDto atualizarUsuarioDto);
        Task Remover(int id);
<<<<<<< HEAD
        Task<Usuario> CriarUsuario(CriarUsuarioDto criarUsuarioDto);
=======
        Task<Usuario> CriarConta(CriarUsuarioDto criarUsuarioDto);
>>>>>>> a4c0c85 (datanotation)
        Task<ECategoria> AdicionarCategoria(CategoriaDto categoriaDto);
        Task RemoverCategoria(CategoriaDto categoriaDto);
        Task<IEnumerable<string>?> ObterCategorias(int idUsuario);
        Task<IEnumerable<EmpresaColetoraDto>?> ObterEmpresasPorCategoriaUsuario(int idUsuario);
    }
}