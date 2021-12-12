
using DesafioAtos.Domain.Core;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Dtos.Token;
using DesafioAtos.Domain.Entidades;
using DesafioAtos.Domain.Mapper;
using DesafioAtos.Infra.UnitOfWorks;
using DesafioAtos.Service.Exceptions;
using DesafioAtos.Service.Services.Token;
using Np.Cryptography;

namespace DesafioAtos.Service.Services.Autenticacao
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICriptografo _criptografo;
        private readonly string _passwordKey;
        private readonly ITokenService _tokenService;
        private readonly AppConfigEcoleta appConfigEcoleta;

        public AutenticacaoService(
            IUnitOfWork unitOfWork,
            IMapper mapper, 
            AppConfigEcoleta appConfigEcoleta,
            ICriptografo criptografo,
            ITokenService tokenService)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this.appConfigEcoleta = appConfigEcoleta;
            this._criptografo = criptografo;
            this._tokenService = tokenService;
            _passwordKey = appConfigEcoleta.PasswordKey();
        }

        public async Task<TokenResponseDto> LogarUsuario(LogarUsuarioDto? loginDto)
        {
            Usuario? usuario = await _unitOfWork.Users.ObterPorLoginAsync(loginDto?.Login);
            ValidarUsuario(usuario, loginDto);
            var createTokenDto = _mapper.MapUsuarioToCreateTokenDto(usuario);
            return _tokenService.CriarToken(createTokenDto);
        }

        private void ValidarUsuario(Usuario? usuario, LogarUsuarioDto loginDto) 
        {
            var encryptedPassword = _criptografo.Criptografar(_passwordKey, loginDto.Senha);
            bool isUsuarioSenhaInvalido = usuario == null || !usuario.Senha.Equals(encryptedPassword);

            if (isUsuarioSenhaInvalido)
            {
                throw new BadRequestException("Usuario ou senha inválida!");
            }
        }
    }
}
