using DesafioAtos.Domain.Dtos;


namespace DesafioAtos.Service.Services.EmpresaColetora
{
    public interface IEmpresaColetoraService
    {

        Task<DesafioAtos.Domain.Entidades.EmpresaColetora> CriarEmpresaColetora(CriarEmpresaColetoraDto criarEmpresaColetoraDto);
        Task AtualizarEmpresaColetora(EditarEmpresaColetoraDto atualizarEmpresaColetoraDto);
        Task Remover(long id);
        Task<IEnumerable<string>> ObterEmpresaColetaPorId(long idEmpresa);
        Task<IEnumerable<string>> ObterEmpresaColeta();
        
    }
}
