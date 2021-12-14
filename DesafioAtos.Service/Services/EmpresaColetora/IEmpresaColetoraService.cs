using DesafioAtos.Domain.Dtos;
using DesafioAtos.Service.Fabrica.Services;

namespace DesafioAtos.Service.Services.EmpresaColetora
{
    public interface IEmpresaColetoraService
    {
        Task EmpresaColetoraPost(CriarEmpresaColetoraDto request);
        Task EmpresaColetoraPut(EditarEmpresaColetoraDto request);
        Task<EmpresaColetoraDto> GetEmpresaColetoraPorId(long id);
        Task<List<EmpresaColetoraDto>> GetTodasEmpresaColetora();
        Task DeletaEmpresaColetora(long id);
    }
}
