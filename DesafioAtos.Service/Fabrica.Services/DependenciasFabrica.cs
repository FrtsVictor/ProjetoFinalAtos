using DesafioAtos.Domain.Core;
using DesafioAtos.Domain.Mapper;
using DesafioAtos.Infra.UnitWork;
using DesafioAtos.Service.Services.Token;
using Microsoft.Extensions.Logging;
using Np.Cryptography;

namespace DesafioAtos.Service.Fabrica.Services
{
    public abstract class DependenciasFabrica
    {
        protected IUnitOfWork _unitOfWork = null!;
        protected IMapper _mapper = null!;
        protected ICriptografo _criptografo = null!;
        protected ITokenService _tokenService = null!;
        protected AppConfigEcoleta _appConfigEcoleta = null!;
        protected ILogger _logger = null!;
    }
}