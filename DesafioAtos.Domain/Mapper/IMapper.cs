using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Dtos.Token;
using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Domain.Mapper
{
    public interface IMapper
    {
        Usuario MapCriarUsuarioDtoToUsuario(CriarUsuarioDto userDto);
        EmpresaColetora MapEmpresaColetoraDtoToEmpresaColetora(EmpresaColetoraDto empresaColetoraDto);
        CreateTokenDto MapUsuarioToCreateTokenDto(Usuario usuario);
        CreateTokenDto MapCriarEmpresaColetoraDtoToCreateTokenDto(EmpresaColetora empresaColetora);
    }
}
