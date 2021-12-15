using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Dtos.Token;
using DesafioAtos.Domain.Entidades;
using DesafioAtos.Domain.Enums;
using DesafioAtos.Domain.Exceptions;

namespace DesafioAtos.Domain.Mapper
{
    public class Mapper : IMapper
    {
        public CreateTokenDto MapUsuarioToCreateTokenDto(Usuario usuario) => new CreateTokenDto()
        {
            Identificador = usuario.Login,
            Role = ERole.Usuario.ToString(),
            Id = usuario.Id
        };


        public Usuario MapCriarUsuarioDtoToUsuario(CriarUsuarioDto criarUsuarioDto) => new Usuario()
        {
            Login = criarUsuarioDto.Login,
            Senha = criarUsuarioDto.Senha,
            Nome = criarUsuarioDto.Nome
        };

        public EmpresaColetora MapEmpresaColetoraDtoToEmpresaColetora(CriarEmpresaColetoraDto empresaColetoraDto) => new EmpresaColetora()
        {
            
            Cnpj =  empresaColetoraDto.Cnpj,
            Senha = empresaColetoraDto.Senha,
            Email = empresaColetoraDto.Email,
            Nome = empresaColetoraDto.Nome,
            Telefone = empresaColetoraDto.Telefone 


        };

        public CreateTokenDto MapCriarEmpresaColetoraDtoToCreateTokenDto(EmpresaColetora empresaColetora) => new CreateTokenDto()
        {
            Identificador = empresaColetora.Email,
            Role = ERole.EmpresaColetora.ToString(),
            Id = empresaColetora.Id
        };
    }
}
