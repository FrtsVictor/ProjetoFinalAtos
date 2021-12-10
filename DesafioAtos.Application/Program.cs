using DesafioAtos.Application.Controllers;
using DesafioAtos.Application.Core.Middlewares;
using DesafioAtos.Domain.Mapper;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.UnitOfWorks;
using DesafioAtos.Service;
using DesafioAtos.Service.Coleta;
using DesafioAtos.Service.EmpresaColetora;
using DesafioAtos.Service.Usuarios;
using Microsoft.EntityFrameworkCore;
using Np.Cryptography;

var builder = WebApplication.CreateBuilder(args);
var cryptography = new Criptografo();
var dbKey = builder.Configuration["cryptography:AppDbKey"];
var tokenKey = builder.Configuration["jwtKey"];
var connectionString = cryptography.Descriptografar(dbKey, builder.Configuration.GetConnectionString("AppDb"));

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IAutenticacaoService, UserAuthenticationService>();
builder.Services.AddScoped<IEmpresaColetoraService, EmpresaColetoraService>();
builder.Services.AddScoped<IColetaService, ColetaService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDatabaseConstraintMapper, DatabaseConstraintMapper>();

builder.Services.AddSingleton<ICriptografo, Criptografo>();
builder.Services.AddSingleton<IFabricaResponse, FabricaResponse>();
builder.Services.AddSingleton<IMapper, Mapper>();
builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("DesafioAtos.Infra")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddEndpointsApiExplorer();

SwaggerMiddlaware.ConfiguarSwagger(builder.Services);
AuthenticationMiddlaware.ConfigurarAutenticacao(builder.Services, tokenKey);

var app = builder.Build();
ConfigureExceptionMiddleware.ConfigureExceptionHandler(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();



app.Run();




