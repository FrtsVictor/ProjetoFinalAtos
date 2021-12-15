using DesafioAtos.Domain.Dtos;


namespace DesafioAtos.Service.Services.EmpresaColetora
{
    public interface IEmpresaColetoraService
    {

        Task<DesafioAtos.Domain.Entidades.EmpresaColetora> CriarEmpresaColetora(CriarEmpresaColetoraDto criarEmpresaDto);
        Task<IEnumerable<string>> ObterEmpresaColetoraId(long idEmpresa);
        Task<IEnumerable<string>> ObterEmpresaColetora();
        Task Atualizar(EditarEmpresaColetoraDto atualizarEmpresaDto);
        Task RemoverEmpresaColetora(long id);



    }
}
