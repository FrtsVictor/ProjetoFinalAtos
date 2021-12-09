using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Domain.Mapper
{
    public interface IMapper
    {
        Usuario MapUsuarioDtoToUsuario(CriarUsuarioDto userDto);
    }
}
