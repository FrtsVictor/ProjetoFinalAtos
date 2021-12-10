using DesafioAtos.Domain.Dtos;

namespace DesafioAtos.Service.EmpresaColetora
{
    public interface IEmpresaColetoraService
    {
        Task EmpresaColetoraPost(CriarEmpresaColetoraDto request);
        Task EmpresaColetoraPut(EditarEmpresaColetoraDto request);
        Task<EmpresaColetoraDto> PegaEmpresaColetoraPorId(long id);
        Task<List<EmpresaColetoraDto>> PegaTodasEmpresaColetora();
        Task DeletaEmpresaColetora(long id);
    }
}
