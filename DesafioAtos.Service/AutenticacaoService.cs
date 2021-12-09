
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entidades;
using DesafioAtos.Domain.Mapper;
using DesafioAtos.Infra.UnitOfWorks;
using DesafioAtos.Service.Exceptions;
using Microsoft.Extensions.Configuration;
using Np.Cryptography;

namespace DesafioAtos.Service
{
    public class UserAuthenticationService : IAutenticacaoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICriptografo _criptografo;
        private readonly IConfiguration _configuration;
        private readonly string _chaveParaCriptografia;

        public UserAuthenticationService(IUnitOfWork unitOfWork, IMapper mapper, ICriptografo criptografo, IConfiguration configuration)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._criptografo = criptografo;
            this._configuration = configuration;
            this._chaveParaCriptografia = _configuration["cryptography:AppPasswordKey"];
        }

        public async Task<Usuario> Logar(CriarUsuarioDto criarUsuarioDto)
        {
            var usuarioParaLogin = _mapper.MapUsuarioDtoToUsuario(criarUsuarioDto);
            Usuario usuario = await _unitOfWork.Users.ObterPorLogin(usuarioParaLogin.Login);
            ValidarUsuario(usuario, criarUsuarioDto);

            return usuario;
        }

        public async Task<Usuario> CriarConta(CriarUsuarioDto criarUsuarioDto)
        {
            var usuarioParaCriacao = _mapper.MapUsuarioDtoToUsuario(criarUsuarioDto);
            var senhaCriptografada = _criptografo.Criptografar(_chaveParaCriptografia, usuarioParaCriacao.Senha);
            usuarioParaCriacao.Senha = senhaCriptografada;

            return await _unitOfWork.ExecutarAsync(async () =>
            {
                return await _unitOfWork.Users.CriarAsync(usuarioParaCriacao);
            });
        }

        private void ValidarUsuario(Usuario usuario, CriarUsuarioDto criarUsuarioDto)
        {
            var encryptedPassword = _criptografo.Criptografar(_chaveParaCriptografia, criarUsuarioDto.Senha);

            if (usuario == null || !usuario.Senha.Equals(encryptedPassword))
            {
                throw new BadRequestException("Usuario ou senha inválida!");
            }
        }
    }
}
