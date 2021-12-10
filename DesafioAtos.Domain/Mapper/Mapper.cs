using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Dtos.Token;
using DesafioAtos.Domain.Entidades;
using DesafioAtos.Domain.Enums;
using DesafioAtos.Domain.Exceptions;

namespace DesafioAtos.Domain.Mapper
{
    public class Mapper : IMapper
    {
        public CreateTokenDto MapUsuarioToCreateUserDto(Usuario usuario) => new CreateTokenDto()
        {
            Identificador = usuario.Login,
            Role = ERole.Usuario.ToString(),
            Id = usuario.Id
        };


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

        public Coleta MapColetaDtoToEmpresaColeta(ColetaDto coletaDto) => new Coleta()
        {
            ItemDeColeta = coletaDto.ItemDeColeta,
            Observacao = coletaDto.Observacao
        };
        public EmpresaColetora MapEmpresaColetoraDtoToEmpresaColetora(EmpresaColetoraDto empresaColetoraDto) => new EmpresaColetora()
        {
            Categoria = empresaColetoraDto.Categoria,
            Cnpj =  empresaColetoraDto.Cnpj,
            DataCriacao = empresaColetoraDto.CreatedAt,
            Email = empresaColetoraDto.Email,
            Nome = empresaColetoraDto.Nome,
            Status = empresaColetoraDto.Status,
            Telefone = empresaColetoraDto.Telefone        

        };
    }
}
