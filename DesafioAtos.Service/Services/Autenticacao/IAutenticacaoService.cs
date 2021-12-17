using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Dtos.Token;

namespace DesafioAtos.Service.Services.Autenticacao
<<<<<<< HEAD
{
=======
{ 
>>>>>>> a4c0c85 (datanotation)
    public interface IAutenticacaoService : IBaseService
    {
        Task<TokenResponseDto> LogarUsuario(LogarUsuarioDto loginDto);
        Task<TokenResponseDto> LogarEmpresa(LogarEmpresaDto loginDto);
    }
}