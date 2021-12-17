using DesafioAtos.Application.Controllers;
using DesafioAtos.Domain.Core;
using DesafioAtos.Domain.Mapper;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.UnitWork;
using DesafioAtos.Service.Fabrica.Services;
using DesafioAtos.Service.Services.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Np.Cryptography;

namespace Test.Utils;

public class InicializadorServicos
{
    protected AppConfigEcoleta _appConfigEcolta = null!;
    protected Criptografo _criptografo;
    protected IConfiguration _configuration = null!;
    protected IFabricaService _fabricaService = null!;
    protected IFabricaResponse _fabricaResponse = null!;
    protected UnitOfWork _unitOfWork = null!;
    protected TokenService _tokenService;

    protected void ObterTokenService(AppConfigEcoleta appConfigEcoleta)
    {
        if (_tokenService != null) return;

        var logger = new LoggerFactory().CreateLogger<TokenService>();
        _tokenService = new TokenService(appConfigEcoleta, logger);
    }

    protected void ObterCriptogafo()
    {
        if (_criptografo != null) return;
        _criptografo = new Criptografo();
    }

    protected void ObterAppConfigEcoleta(IConfiguration configuration, Criptografo criptografo)
    {
        var dbKey = configuration["cryptography:AppDbKey"];
        var passwordKey = configuration["cryptography:AppPasswordKey"];
        var tokenKey = configuration["jwtKey"];
        var connectionString = criptografo
            .Descriptografar(dbKey, configuration.GetConnectionString("AppDb"));

        _appConfigEcolta = new AppConfigEcoleta(connectionString, tokenKey, passwordKey);
    }


    protected void ObterUnitOfWork()
    {
        if (_unitOfWork != null) return;

        var databaseContext = new DatabaseContext();
        var logger = new LoggerFactory();
        var loggerDb = new LoggerFactory().CreateLogger<DatabaseConstraintMapper>();
        var dbConstraint = new DatabaseConstraintMapper(loggerDb);
        _unitOfWork = new UnitOfWork(databaseContext, logger, dbConstraint);
    }

    protected void ObterIConfiguration()
    {
        if (_configuration != null) return;
        var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.Development.json", optional: false);
        _configuration = builder.Build();
    }

    protected void ObterFabricaService(AppConfigEcoleta appConfigEcoleta, UnitOfWork unitOfWork,
        TokenService tokenService, Criptografo criptografo)
    {
        if (_fabricaService != null) return;

        IMapper mapper = new Mapper(criptografo, appConfigEcoleta);
        var logger = new LoggerFactory();
        _fabricaService = new FabricaServices(unitOfWork, mapper, criptografo, tokenService, appConfigEcoleta, logger);
    }
}