using DesafioAtos.Domain.Dtos;


namespace DesafioAtos.Service.Services.EmpresaColetora
{
    public interface IEmpresaColetoraService : IBaseService
    {
        Task<int> CriarEmpresaColetora(CriarEmpresaColetoraDto request);
        Task EditarEditarEmpresaColetora(int idEmpresaColetora, EditarEmpresaColetoraDto request);
        Task DeletaEmpresaColetora(int id);
        Task<IEnumerable<string>?> ObterCategorias(int id);
        Task<int> AdicionarEndereco(CriarEnderecoDto enderecoDto, int idEmpresa);
        Task<IEnumerable<EnderecoDto>> ObterEnderecos(int idEmpresa);
    }
}
