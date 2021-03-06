
using DesafioAtos.Domain.Core;
using DesafioAtos.Domain.Mapper;
using DesafioAtos.Infra.UnitWork;
using DesafioAtos.Service.Services.Autenticacao;
using DesafioAtos.Service.Services.EmpresaColetora;
using DesafioAtos.Service.Services.Token;
using DesafioAtos.Service.Services.Usuarios;
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
            ILoggerFactory loggerFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _criptografo = criptografo;
            _tokenService = tokenService;
            _appConfigEcoleta = appConfigEcoleta;
            _logger = loggerFactory.CreateLogger("Log Service");
        }

        public ITokenService TokenService => _tokenService;

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
                    _usuarioService ??= new UsuarioService(_unitOfWork, _mapper);
                    break;
                case EFabricaService.EnderecoService:
                    break;
                case EFabricaService.EmpresaColetoraService:
                    _empresaColetoraService ??= new EmpresaColetoraService(_unitOfWork, _mapper);
                    break;
                case EFabricaService.AutenticacaoService:
                    _autenticacaoService ??=
                        new AutenticacaoService(_unitOfWork, _mapper, _criptografo, _tokenService,
                            _appConfigEcoleta.PasswordKey());
                    break;
                default:
                    throw new Exception("Servico inv??lido");
            }
        }
    }
}