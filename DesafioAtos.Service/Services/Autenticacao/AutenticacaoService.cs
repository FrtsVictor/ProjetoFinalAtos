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
            ValidarUsuario(usuario, loginDto.Senha);
            var createTokenDto = _mapper.MapUsuarioToCreateTokenDto(usuario);
            return _tokenService.CriarToken(createTokenDto);
        }

        public async Task<TokenResponseDto> LogarEmpresa(LogarEmpresaDto loginDto)
        {
            var empresaColetora = await _unitOfWork.EmpresaColetoraRepository.ObterPorEmail(loginDto.Email);
            ValidarUsuario(empresaColetora, loginDto.Senha);
            var createTokenDto = _mapper.MapCriarEmpresaColetoraDtoToCreateTokenDto(empresaColetora);
            return _tokenService.CriarToken(createTokenDto);
        }

        private void ValidarUsuario<T>(T usuario, string senha)
        {
            var encryptedPassword = _criptografo.Criptografar(_passwordKey, senha);
            bool isUsuarioSenhaInvalido = usuario == null || !senha.Equals(encryptedPassword);

            if (isUsuarioSenhaInvalido)
            {
                throw new BadRequestException("Usuario ou senha inválida!");
            }
        }
    }
}
