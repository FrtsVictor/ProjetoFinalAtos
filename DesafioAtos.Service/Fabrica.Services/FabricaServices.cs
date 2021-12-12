using DesafioAtos.Domain.Core;
using DesafioAtos.Domain.Mapper;
using DesafioAtos.Infra.UnitOfWorks;
using DesafioAtos.Service.Services.Autenticacao;
using DesafioAtos.Service.Services.EmpresaColetora;
using DesafioAtos.Service.Services.Token;
using DesafioAtos.Service.Usuarios;
using Microsoft.Extensions.Logging;
using Np.Cryptography;

namespace DesafioAtos.Service.Fabrica.Services
{
    public class FabricaServices : DependenciasFabrica, IFabricaService
    {
        public FabricaServices(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICriptografo criptografo,
            ITokenService tokenService,
            AppConfigEcoleta appConfigEcoleta,
            AutoMapper.IMapper autoMapper,
            ILoggerFactory loggerFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _criptografo = criptografo;
            _tokenService = tokenService;
            _appConfigEcoleta = appConfigEcoleta;
            _autoMapper = autoMapper;
            _logger = loggerFactory.CreateLogger("Log Service");
        }

        private IAutenticacaoService _autenticacaoService = null!;
        public IAutenticacaoService AutenticacaoService
        {
            get
            {
                InstanciarServiceIfNull(EFabricaService.AutenticacaoService);
                return _autenticacaoService;
            }
        }


        private IUsuarioService _usuarioService = null!;
        public IUsuarioService UsuarioService
        {
            get
            {
                InstanciarServiceIfNull(EFabricaService.UsuarioService);
                return _usuarioService;
            }
        }

        private ITokenService _tokenService = null!;
        public ITokenService TokenService
        {
            get
            {
                InstanciarServiceIfNull(EFabricaService.TokenService);
                return _tokenService;
            }
        }


        private IEmpresaColetoraService _empresaColetoraService = null!;
        public IEmpresaColetoraService EmpresaColetoraService
        {
            get
            {
                InstanciarServiceIfNull(EFabricaService.EmpresaColetoraService);
                return _empresaColetoraService;
            }
        }


        private void InstanciarServiceIfNull(EFabricaService tipoRepository)
        {
            switch (tipoRepository)
            {
                case EFabricaService.UsuarioService:
                    if (_usuarioService == null)
                        _usuarioService = new UsuarioService(_unitOfWork, _mapper, _appConfigEcoleta, _criptografo);
                    break;
                case EFabricaService.EnderecoService:
                    break;
                case EFabricaService.EmpresaColetoraService:
                    if (_empresaColetoraService == null)
                        _empresaColetoraService = new EmpresaColetoraService(_unitOfWork, _autoMapper, _appConfigEcoleta, _criptografo);
                    break;
                case EFabricaService.AutenticacaoService:
                    if (_autenticacaoService == null)
                        _autenticacaoService = new AutenticacaoService(_unitOfWork, _mapper, _appConfigEcoleta, _criptografo, TokenService);
                    break;
                case EFabricaService.TokenService:
                    if (_tokenService == null)
                        _tokenService = new TokenService(_appConfigEcoleta, _logger);
                    break;
                default:
                    throw new Exception("Servico inválido");
            }
        }
    }
}