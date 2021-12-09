using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Dtos.Token;
using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Domain.Mapper
{
    public interface IMapper
    {
        Usuario MapUsuarioDtoToUsuario(CriarUsuarioDto userDto);
        CreateTokenDto MapUsuarioToCreateUserDto(Usuario usuario);
    }
}
