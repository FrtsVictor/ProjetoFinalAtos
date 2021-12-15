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

void AplicarDependencias(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
}

void ConfigurarControllers(WebApplicationBuilder builder)
{
    builder.Services.AddControllers()
        .ConfigureApiBehaviorOptions(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        })
        .AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

    builder.Services.AddEndpointsApiExplorer();
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

void InjetarDependencias(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IDatabaseConstraintMapper, DatabaseConstraintMapper>();
    builder.Services.AddScoped<IFabricaService, FabricaServices>();

    builder.Services.AddSingleton<AppConfigEcoleta>(appConfigEcoleta);
    builder.Services.AddSingleton<ICriptografo, Criptografo>();
    builder.Services.AddSingleton<IFabricaResponse, FabricaResponse>();
    builder.Services.AddSingleton<IMapper, Mapper>();
    builder.Services.AddSingleton<ITokenService, TokenService>();

    builder.Services.AddDbContext<DatabaseContext>(options => options
        .UseSqlServer(appConfigEcoleta
            .ConnectionString(), x => x.MigrationsAssembly("DesafioAtos.Infra")));
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
}


public partial class Program { }