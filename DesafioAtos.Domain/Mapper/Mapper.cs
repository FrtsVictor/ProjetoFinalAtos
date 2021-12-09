using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entidades;
using DesafioAtos.Domain.Enums;
using DesafioAtos.Domain.Exceptions;

namespace DesafioAtos.Domain.Mapper
{
    public class Mapper : IMapper
    {
        public Usuario MapUsuarioDtoToUsuario(CriarUsuarioDto criarUsuarioDto) => new Usuario()
        {
            Login = criarUsuarioDto.Login,
            Senha = criarUsuarioDto.Senha,
            Role = ObterEnum(criarUsuarioDto.RoleId)
        };

        public ERole ObterEnum(int valor)
        {
            if (!Enum.IsDefined(typeof(ERole), valor))
            {
                throw new InvalidEnumException("Role inv�lido!");
            }

            return (ERole)valor;
        }

    }
}
