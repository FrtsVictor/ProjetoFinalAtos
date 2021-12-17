using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Dtos.Token;
using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Domain.Mapper
{
    public interface IMapper
    {
        Usuario MapCriarUsuarioDtoToUsuario(CriarUsuarioDto userDto = null!);
        EmpresaColetora MapCriarEmpresaDtoToEmpresaColetora(CriarEmpresaColetoraDto empresaColetoraDto = null!);
        CreateTokenDto MapUsuarioToCreateTokenDto(Usuario usuario = null!);
        CreateTokenDto MapCriarEmpresaToCreateTokenDto(EmpresaColetora empresaColetora = null!);
        Endereco MapCriarEnderecoDtoToEndereco(CriarEnderecoDto criarEnderecoDto = null!);
        void MapEditarEmpresaDtoToEmpresaColetora(EditarEmpresaColetoraDto empresaColetoraDto,
            EmpresaColetora empresaColetora = null!);
        void MapEditarUsuarioDtoToUsuario(EditarUsuarioDto usuarioDto, Usuario usuario = null!);
        EmpresaColetoraDto MapEmpresaColetoraToEmpresaColetoraDto(EmpresaColetora empresaColetora);
        EnderecoDto MapEnderecoToEnderecoDto(Endereco? endereco);
        void MapEditarEnderecoToEndereco(EditarEnderecoDto editarEnderecoDto, Endereco endereco);
        UsuarioDto MapUsuarioToUsuarioDto(Usuario usuario);
        CategoriaEmpresa CriarCategoriaEmpresa(int idEmpresa, int idCategoria);
        CategoriaUsuario CriarCategoriaUsuario(int idUsuario, int idCategoria);
        ObterEmpresaDto MapEmpresaToObterEmpresaDto(EmpresaColetora empresa);
    }
}