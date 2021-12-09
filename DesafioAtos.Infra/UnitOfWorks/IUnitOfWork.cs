using DesafioAtos.Infra.Repository.Interfaces;

namespace DesafioAtos.Infra.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IColetaRepository ColetaRepository { get; }
        IEmpresaColetoraRepository EmpresaColetoraRepository { get; }
        IEnderecoRepository EnderecoRepository { get; }
        IUsuarioRepository Users { get; }
        Task SalvarAsync();
        Task<T> ExecutarAsync<T>(Func<Task<T>> callback);
        Task VoidExecutarAsync<T>(Func<Task<T>> callback);
    }
}