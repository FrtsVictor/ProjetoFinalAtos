using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Enums;

namespace DesafioAtos.Service.Services.EmpresaColetora
{
    public interface IEmpresaColetoraService : IBaseService
    {
        Task<int> CriarEmpresaColetora(CriarEmpresaColetoraDto request);
        Task EditarEditarEmpresaColetora(int idEmpresaColetora, EditarEmpresaColetoraDto request);
        Task DeletaEmpresaColetora(int id);
        Task<IEnumerable<string>?> ObterCategorias(int id);
        Task<int> AdicionarEndereco(CriarEnderecoDto enderecoDto, int idEmpresa);
<<<<<<< HEAD
        Task<IEnumerable<EnderecoDto>?> ObterEnderecos(int idEmpresa);
=======
        Task<IEnumerable<EnderecoDto>> ObterEnderecos(int idEmpresa);
>>>>>>> a4c0c85 (datanotation)
        Task EditarEndereco(int idEmpresa, EditarEnderecoDto editarEnderecoDto);
        Task RemoverEndereco(int idEndereco);
        Task<ECategoria> AdicionarCategoria(CategoriaDto adicionarCategoriaDto);
        Task RemoverCategoria(CategoriaDto categoriaDto);
    }
}