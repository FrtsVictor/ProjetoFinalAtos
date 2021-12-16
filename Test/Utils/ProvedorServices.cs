using System;
using System.Diagnostics;
using System.Threading.Tasks;
using DesafioAtos.Application.Controllers;
using DesafioAtos.Domain.Dtos.Token;
using DesafioAtos.Infra.UnitWork;
using DesafioAtos.Service.Fabrica.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Test.Utils;

public class ServiceProvider
{
    private static IFabricaService _fabricaService = null!;
    private static IFabricaResponse _fabricaResponse = null!;
    private static IUnitOfWork _unitOfWork = null!;

    public async Task<string> ObterToken()
    {
        var usuario = await _unitOfWork.Users.ObterPorLoginAsync("Test__");
        Debug.Assert(usuario != null, nameof(usuario) + " != null");
        var createTOken = new CreateTokenDto()
            {Id = usuario.Id, Identificador = usuario.Login, Role = usuario.Role.ToString()};

        return _fabricaService.TokenService.CriarToken(createTOken).Token ?? throw new InvalidOperationException();
    }

    public static IFabricaService FabricaService
    {
        get { return _fabricaService ??= ObterWebApplication().Services.GetService<IFabricaService>()!; }
    }

    public static IFabricaResponse FabricaResponse
    {
        get { return _fabricaResponse ??= ObterWebApplication().Services.GetService<IFabricaResponse>()!; }
    }

    public static IUnitOfWork UnitOfWork
    {
        get { return _unitOfWork ??= ObterWebApplication().Services.GetService<IUnitOfWork>()!; }
    }

    private static WebApplicationFactory<Program> ObterWebApplication() =>
        new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder => { builder.ConfigureServices(services => { }); });
}