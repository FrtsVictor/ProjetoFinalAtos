using System;
using System.Threading.Tasks;
using DesafioAtos.Application.Controllers;
using DesafioAtos.Domain.Core;
using DesafioAtos.Domain.Dtos.Token;
using DesafioAtos.Domain.Enums;
using DesafioAtos.Infra.UnitWork;
using DesafioAtos.Service.Fabrica.Services;
using DesafioAtos.Service.Services.Token;
using Microsoft.Extensions.Configuration;
using Np.Cryptography;

namespace Test.Utils;

public class ProvedorServices : InicializadorServicos
{
    public AppConfigEcoleta AppConfigEcoleta
    {
        get
        {
            var configuration = Configuration;
            var criptografo = Criptografo;
            ObterAppConfigEcoleta(configuration, criptografo);
            return _appConfigEcolta;
        }
    }


    public Criptografo Criptografo
    {
        get
        {
            ObterCriptogafo();
            return _criptografo;
        }
    }


    public IConfiguration Configuration
    {
        get
        {
            ObterIConfiguration();
            return _configuration;
        }
    }


    public IFabricaService FabricaService
    {
        get
        {
            var token = TokenService;
            var config = AppConfigEcoleta;
            var uniOfWork = UnitOfWork;
            var criptofrafo = Criptografo;

            ObterFabricaService(config, uniOfWork, token, criptofrafo);
            return _fabricaService;
        }
    }


    public IFabricaResponse FabricaResponse
    {
        get
        {
            if (_fabricaResponse != null) return _fabricaResponse;
            _fabricaResponse = new FabricaResponse();
            return _fabricaResponse;
        }
    }


    public UnitOfWork UnitOfWork
    {
        get
        {
            ObterUnitOfWork();
            return _unitOfWork;
        }
    }

    public TokenService TokenService
    {
        get
        {
            var appConfigEcoleta = AppConfigEcoleta;
            ObterTokenService(appConfigEcoleta);
            return _tokenService;
        }
    }


    public async Task<string> ObterToken(string login = "Test__")
    {
        var usuario = await UnitOfWork.Users.ObterPorLoginAsync(login);
        var createToken = new CreateTokenDto()
            {Id = usuario.Id, Identificador = usuario.Login, Role = ERole.Usuario.ToString()};

        var response = FabricaService.TokenService.CriarToken(createToken);
        return response.Token ?? throw new InvalidOperationException();
    }
}