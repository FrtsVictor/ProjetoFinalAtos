
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Dtos.Token;
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
        private readonly ITokenService _tokenService;

        public UserAuthenticationService(IUnitOfWork unitOfWork, IMapper mapper, ICriptografo criptografo, IConfiguration configuration, ITokenService tokenService)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._criptografo = criptografo;
            this._configuration = configuration;
            this._chaveParaCriptografia = _configuration["cryptography:AppPasswordKey"];
            this._tokenService = tokenService;
        }

        public async Task<TokenResponseDto> Logar(LogarUsuarioDto? loginDto)
        {            
            Usuario usuario = await _unitOfWork.Users.ObterPorLogin(loginDto?.Login);
            ValidarUsuario(usuario, loginDto);
            var createTokenDto = _mapper.MapUsuarioToCreateUserDto(usuario);
            return _tokenService.CriarToken(createTokenDto);            
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

        private void ValidarUsuario(Usuario usuario, LogarUsuarioDto? loginDto)
        {
            var encryptedPassword = _criptografo.Criptografar(_chaveParaCriptografia, loginDto?.Senha);

            if (usuario == null || !usuario.Senha.Equals(encryptedPassword))
            {
                throw new BadRequestException("Usuario ou senha inválida!");
            }
        }
    }
}
