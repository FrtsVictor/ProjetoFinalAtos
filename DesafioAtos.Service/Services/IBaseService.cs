namespace DesafioAtos.Service.Services
{
    public interface IBaseService
    {
        void ValidarEntidade(bool isTrue, string mensagemErro);
        void ValidarCategoria(int value);
    }
}