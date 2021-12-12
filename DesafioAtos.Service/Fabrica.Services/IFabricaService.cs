using DesafioAtos.Service.Services.Autenticacao;
using DesafioAtos.Service.Services.EmpresaColetora;
using DesafioAtos.Service.Services.Token;
using DesafioAtos.Service.Usuarios;

namespace DesafioAtos.Service.Fabrica.Services
{
    public interface IFabricaService
    {
        IAutenticacaoService AutenticacaoService { get; }
        IUsuarioService UsuarioService { get; }
        ITokenService TokenService { get; }
        IEmpresaColetoraService EmpresaColetoraService { get; }
    }
}