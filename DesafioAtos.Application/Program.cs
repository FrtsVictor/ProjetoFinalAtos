using DesafioAtos.Application.Controllers;
using DesafioAtos.Application.Core.Middlewares;
using DesafioAtos.Domain.Core;
using DesafioAtos.Domain.Mapper;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.UnitWork;
using Microsoft.EntityFrameworkCore;
using Np.Cryptography;
using DesafioAtos.Service.Fabrica.Services;
using DesafioAtos.Service.Services.Token;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var appConfigEcoleta = CriarAppConfigEcoleta(builder);
ConfigurarControllers(builder);
InjetarDependencias(builder);
SwaggerMiddlaware.ConfiguarSwagger(builder.Services);
AuthenticationMiddlaware.ConfigurarAutenticacao(builder.Services, appConfigEcoleta.JwtKey());

WebApplication app = builder.Build();
ConfigureExceptionMiddleware.ConfigureExceptionHandler(app);
AplicarDependencias(app);
app.Run();

void AplicarDependencias(WebApplication appSettings)
{
    if (appSettings.Environment.IsDevelopment())
    {
        appSettings.UseSwagger();
        appSettings.UseSwaggerUI();
    }

    appSettings.UseHttpsRedirection();
    appSettings.UseAuthentication();
    appSettings.UseAuthorization();

    appSettings.MapControllers();
}

void ConfigurarControllers(WebApplicationBuilder appBuilder)
{
    appBuilder.Services.AddControllers()
        .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; })
        .AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

    appBuilder.Services.AddEndpointsApiExplorer();
}

AppConfigEcoleta CriarAppConfigEcoleta(WebApplicationBuilder webBuild)
{
    var criptografo = new Criptografo();
    var dbKey = webBuild.Configuration["cryptography:AppDbKey"];
    var passwordKey = webBuild.Configuration["cryptography:AppPasswordKey"];
    var tokenKey = webBuild.Configuration["jwtKey"];
    var connectionString = criptografo
        .Descriptografar(dbKey, webBuild.Configuration.GetConnectionString("AppDb"));

    return new AppConfigEcoleta(connectionString, tokenKey, passwordKey);
}

void InjetarDependencias(WebApplicationBuilder appBuilder)
{
    appBuilder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    appBuilder.Services.AddScoped<IDatabaseConstraintMapper, DatabaseConstraintMapper>();
    appBuilder.Services.AddScoped<IFabricaService, FabricaServices>();

    appBuilder.Services.AddSingleton<AppConfigEcoleta>(appConfigEcoleta);
    appBuilder.Services.AddSingleton<ICriptografo, Criptografo>();
    appBuilder.Services.AddSingleton<IFabricaResponse, FabricaResponse>();
    appBuilder.Services.AddSingleton<IMapper, Mapper>();
    appBuilder.Services.AddSingleton<ITokenService, TokenService>();

    appBuilder.Services.AddDbContext<DatabaseContext>(opt => opt
        .UseSqlServer(appConfigEcoleta
            .ConnectionString(), x => x.MigrationsAssembly("DesafioAtos.Infra")));
    appBuilder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
}


public partial class Program
{
}