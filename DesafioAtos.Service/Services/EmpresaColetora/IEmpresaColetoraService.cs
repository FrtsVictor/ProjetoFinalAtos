using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Enums;


namespace DesafioAtos.Service.Services.EmpresaColetora
{
    public interface IEmpresaColetoraService : IBaseService
    {
        Task<int> CriarEmpresaColetora(CriarEmpresaColetoraDto request);
        Task EditarEmpresaColetora(int idEmpresaColetora, EditarEmpresaColetoraDto request);
        Task DeletaEmpresaColetora(int id);
        Task<IEnumerable<string>?> ObterCategorias(int id);
        Task<int> AdicionarEndereco(CriarEnderecoDto enderecoDto, int idEmpresa);
        Task<IEnumerable<EnderecoDto>?> ObterEnderecos(int idEmpresa);
        Task EditarEndereco(int idEmpresa, EditarEnderecoDto editarEnderecoDto);
        Task RemoverEndereco(int idEndereco);
        Task<ECategoria> AdicionarCategoria(CategoriaDto adicionarCategoriaDto);
        Task RemoverCategoria(CategoriaDto categoriaDto);
    }
}