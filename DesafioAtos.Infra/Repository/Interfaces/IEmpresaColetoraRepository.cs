using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Infra.Repository.Interfaces
{
    public interface IEmpresaColetoraRepository : IBaseRepository<EmpresaColetora>
    {
        Task<EmpresaColetora?> ObterPorEmail(string email);
    }
}