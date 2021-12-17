using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Dtos.Token;
using DesafioAtos.Domain.Mapper;
using DesafioAtos.Infra.UnitWork;
using DesafioAtos.Service.Exceptions;
using DesafioAtos.Service.Services.Token;
using Np.Cryptography;

namespace DesafioAtos.Service.Services.Autenticacao
{
    public class AutenticacaoService : BaseService, IAutenticacaoService
    {
<<<<<<< HEAD
        public const string UsuarioSenhaInvalidos = "Usuario ou senha invalidos.";
=======
        public const string USUARIO_SENHA_INVALIDOS = "Usuario ou senha invalidos.";
>>>>>>> a4c0c85 (datanotation)
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICriptografo _criptografo;
        private readonly string _passwordKey;
        private readonly ITokenService _tokenService;

        public AutenticacaoService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICriptografo criptografo,
            ITokenService tokenService,
            string passwordKey)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._criptografo = criptografo;
            this._tokenService = tokenService;
            _passwordKey = passwordKey;
        }

        public async Task<TokenResponseDto> LogarUsuario(LogarUsuarioDto loginDto)
        {
            var usuario = await _unitOfWork.Users.ObterPorLoginAsync(loginDto.Login);
<<<<<<< HEAD
            ValidarEntidade(usuario == null, UsuarioSenhaInvalidos);
            ValidarSenha(loginDto.Senha, usuario!.Senha);
=======
            ValidarEntidade(usuario == null, USUARIO_SENHA_INVALIDOS);
            ValidarSenha(loginDto.Senha, usuario.Senha);
>>>>>>> a4c0c85 (datanotation)
            var createTokenDto = _mapper.MapUsuarioToCreateTokenDto(usuario);
            return _tokenService.CriarToken(createTokenDto);
        }

        public async Task<TokenResponseDto> LogarEmpresa(LogarEmpresaDto loginDto)
        {
            var empresaColetora = await _unitOfWork.EmpresaColetora.ObterPorEmail(loginDto.Email);
<<<<<<< HEAD
            ValidarEntidade(empresaColetora == null, UsuarioSenhaInvalidos);
            ValidarSenha(loginDto.Senha, empresaColetora!.Senha);
=======
            ValidarEntidade(empresaColetora == null, USUARIO_SENHA_INVALIDOS);
            ValidarSenha(loginDto.Senha, empresaColetora.Senha);
>>>>>>> a4c0c85 (datanotation)

            var createTokenDto = _mapper.MapCriarEmpresaToCreateTokenDto(empresaColetora);
            return _tokenService.CriarToken(createTokenDto);
        }

        private void ValidarSenha(string senhaLogin, string senhaSalvaNoBanco = null!)
        {
            var senhaLoginCriptografada = _criptografo.Criptografar(_passwordKey, senhaLogin);
            var isSenhaInvalida = !senhaSalvaNoBanco.Equals(senhaLoginCriptografada);

            if (isSenhaInvalida)
<<<<<<< HEAD
                throw new BadRequestException(UsuarioSenhaInvalidos);
=======
                throw new BadRequestException(USUARIO_SENHA_INVALIDOS);
>>>>>>> a4c0c85 (datanotation)
        }
    }
}
