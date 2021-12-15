using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Infra.Repository.Interfaces
{
    public interface IEnderecoRepository : IBaseRepository<Endereco>
    {
        Task<IEnumerable<Endereco?>> ObterTodosPorIdEmpresaAsync(int idEmpresa);
    }
}