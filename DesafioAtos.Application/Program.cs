using DesafioAtos.Application.Controllers;
using DesafioAtos.Application.Core.Middlewares.Exceptions;
using DesafioAtos.Application.Core.Swagger;
using DesafioAtos.Domain.Mapper;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.UnitOfWorks;
using DesafioAtos.Service;
using DesafioAtos.Service.Coleta;
using DesafioAtos.Service.EmpresaColetora;
using DesafioAtos.Service.Usuarios;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Np.Cryptography;

var builder = WebApplication.CreateBuilder(args);
var dbKey = builder.Configuration["cryptography:AppDbKey"];
var cryptography = new Criptografo();
var connectionString = cryptography.Descriptografar(dbKey, builder.Configuration.GetConnectionString("AppDb"));
var environment = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");


builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IAutenticacaoService, UserAuthenticationService>();
builder.Services.AddScoped<IEmpresaColetoraService, EmpresaColetoraService>();
builder.Services.AddScoped<IColetaService, ColetaService>();

builder.Services.AddSingleton<ICriptografo, Criptografo>();
builder.Services.AddSingleton<IFabricaResponse, FabricaResponse>();
builder.Services.AddSingleton<IMapper, Mapper>();
builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDatabaseConstraintMapper, DatabaseConstraintMapper>();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("DesafioAtos.Infra")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

builder.Services.AddEndpointsApiExplorer();
SwaggerMiddlaware.ConfiguarSwagger(builder.Services);

var app = builder.Build();
ConfigureExceptionMiddleware.ConfigureExceptionHandler(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();




