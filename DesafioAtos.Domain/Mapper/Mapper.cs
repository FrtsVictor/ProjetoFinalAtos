using DesafioAtos.Domain.Core;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Dtos.Token;
using DesafioAtos.Domain.Entidades;
using DesafioAtos.Domain.Enums;
using Np.Cryptography;

namespace DesafioAtos.Domain.Mapper
{
    public class Mapper : IMapper
    {
        private readonly ICriptografo _criptografo;
        private readonly string _passKey;
        public Mapper(ICriptografo criptografo, AppConfigEcoleta appConfigEcoleta)
        {
            this._passKey = appConfigEcoleta.PasswordKey();
            this._criptografo = criptografo;
        }

        public CreateTokenDto MapUsuarioToCreateTokenDto(Usuario usuario) => new CreateTokenDto()
        {
            Identificador = usuario.Login,
            Role = ERole.Usuario.ToString(),
            Id = usuario.Id
        };


        public Usuario MapCriarUsuarioDtoToUsuario(CriarUsuarioDto criarUsuarioDto) => new Usuario()
        {
            Login = criarUsuarioDto.Login,
            Senha = _criptografo.Criptografar(_passKey, criarUsuarioDto.Senha),
            Nome = criarUsuarioDto.Nome
        };

        public EmpresaColetora MapCriarEmpresaDtoToEmpresaColetora(CriarEmpresaColetoraDto empresaColetoraDto) => new EmpresaColetora()
        {
            Cnpj = empresaColetoraDto.Cnpj,
            Email = empresaColetoraDto.Email,
            Nome = empresaColetoraDto.Nome,
            Telefone = empresaColetoraDto.Telefone,
            Senha = _criptografo.Criptografar(_passKey, empresaColetoraDto.Senha),
            Enderecos = empresaColetoraDto.Enderecos.Select(MapCriarEnderecoDtoToEndereco).ToList()
        };

        public Endereco MapCriarEnderecoDtoToEndereco(CriarEnderecoDto criarEnderecoDto) => new Endereco()
        {
            Bairro = criarEnderecoDto.Bairro,
            Cep = criarEnderecoDto.Cep,
            Cidade = criarEnderecoDto.Cidade,
            Complemento = criarEnderecoDto.Complemento,
            Estado = criarEnderecoDto.Estado,
            Numero = criarEnderecoDto.Numero,
            Rua = criarEnderecoDto.Rua,
            Status = true
        };

        public CreateTokenDto MapCriarEmpresaToCreateTokenDto(EmpresaColetora empresaColetora) => new CreateTokenDto()
        {
            Identificador = empresaColetora.Email,
            Role = ERole.EmpresaColetora.ToString(),
            Id = empresaColetora.Id
        };

        public void MapEditarEmpresaDtoToEmpresaColetora(EditarEmpresaColetoraDto editarEmpresaDto,
             EmpresaColetora empresaColetora)
        {
            empresaColetora.Email = editarEmpresaDto.Email ?? empresaColetora.Email;
            empresaColetora.Cnpj = editarEmpresaDto.Cnpj ?? empresaColetora.Cnpj;
            empresaColetora.Nome = editarEmpresaDto.Nome ?? empresaColetora.Nome;
            empresaColetora.Telefone = editarEmpresaDto.Telefone ?? empresaColetora.Telefone;
            empresaColetora.Senha = string.IsNullOrEmpty(editarEmpresaDto.Senha)
                ? empresaColetora.Senha
                : _criptografo.Criptografar(_passKey, editarEmpresaDto.Senha);
        }

        public void MapEditarUsuarioDtoToUsuario(EditarUsuarioDto usuarioDto, Usuario usuario)
        {
            usuario.Login = usuarioDto.Login ?? usuario.Login;
            usuario.Nome = usuarioDto.Nome ?? usuario.Nome;
            usuario.Senha = string.IsNullOrEmpty(usuarioDto.Senha)
                ? usuario.Senha
                : _criptografo.Criptografar(_passKey, usuarioDto.Senha);
        }

        public CategoriaUsuario CriarCategoriaUsuario(int idUsuario, int idCategoria) => new CategoriaUsuario()
        {
            IdUsuario = idUsuario,
            IdCategoria = idCategoria
        };

        public EnderecoDto MapEnderecoToEnderecoDto(Endereco endereco) => new EnderecoDto
        {
            Id = endereco.Id,
            Bairro = endereco.Bairro,
            Cep = endereco.Cep,
            Cidade = endereco.Cidade,
            Complemento = endereco.Complemento,
            Estado = endereco.Estado,
            Numero = endereco.Numero,
            Rua = endereco.Rua
        };

        public EmpresaColetoraDto MapEmpresaColetoraToEmpresaColetoraDto(EmpresaColetora empresaColetora) => new EmpresaColetoraDto
        {
            Email = empresaColetora.Email,
            Enderecos = empresaColetora.Enderecos.Select(MapEnderecoToEnderecoDto).ToList(),
            Nome = empresaColetora.Nome,
            Telefone = empresaColetora.Telefone
        };

        public void MapEditarEnderecoToEndereco(EditarEnderecoDto editarEnderecoDto, Endereco endereco)
        {
            endereco.Bairro = editarEnderecoDto.Bairro ?? endereco.Bairro;
            endereco.Cep = editarEnderecoDto.Cep ?? endereco.Cep;
            endereco.Cidade = editarEnderecoDto.Cidade ?? endereco.Cidade;
            endereco.Complemento = editarEnderecoDto.Complemento ?? endereco.Complemento;
            endereco.Estado = editarEnderecoDto.Estado ?? endereco.Estado;
            endereco.Rua = editarEnderecoDto.Rua ?? endereco.Rua;
            endereco.Numero = editarEnderecoDto.Numero ?? endereco.Numero;
        }

        public CategoriaEmpresa CriarCategoriaEmpresa(int idEmpresa, int idCategoria) => new CategoriaEmpresa
        {
            IdCategoria = idCategoria,
            IdEmpresaColetora = idEmpresa
        };
    }
}