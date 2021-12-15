using DesafioAtos.Infra.Repository.Interfaces;

namespace DesafioAtos.Infra.UnitWork
{
    public interface IUnitOfWork
    {
        IEmpresaColetoraRepository EmpresaColetora { get; }
        IEnderecoRepository Endereco { get; }
        IUsuarioRepository Users { get; }
        ICategoriaEmpresaRepository CategoriaEmpresa { get; }
        ICategoriaUsuarioRepository CategoriaUsuario { get; }
        Task SalvarAsync();
        Task<T> ExecutarAsync<T>(Func<Task<T>> callback);
        Task VoidExecutarAsync(Func<Task> callback);
        Task ExecutarTransacaoAsync(params Func<Task>[] @callbacks);
        void Executar<T>(Func<T> callback);
    }
}