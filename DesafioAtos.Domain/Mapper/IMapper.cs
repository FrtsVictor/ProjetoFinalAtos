using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Dtos.Token;
using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Domain.Mapper
{
    public interface IMapper
    {
       CreateTokenDto MapUsuarioToCreateTokenDto(Usuario usuario);
       Usuario MapCriarUsuarioDtoToUsuario(CriarUsuarioDto criarUsuarioDto);
        CreateTokenDto MapCriarEmpresaColetoraDtoToCreateTokenDto(EmpresaColetora empresaColetora);
        EmpresaColetora MapEmpresaColetoraDtoToEmpresaColetora(EmpresaColetoraDto empresaColetoraDto);
    }
}
