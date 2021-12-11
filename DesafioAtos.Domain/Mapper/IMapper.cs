using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Dtos.Token;
using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Domain.Mapper
{
    public interface IMapper
    {
        Usuario MapUsuarioDtoToUsuario(CriarUsuarioDto userDto);
        EmpresaColeta MapEmpresaColetoraDtoToEmpresaColetora(EmpresaColetoraDto empresaColetoraDto);
        CreateTokenDto MapUsuarioToCreateUserDto(Usuario usuario);

    }
}
