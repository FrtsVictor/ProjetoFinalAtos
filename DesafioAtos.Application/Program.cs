using DesafioAtos.Application.Controllers;
using DesafioAtos.Application.Core.Middlewares.Exceptions;
using DesafioAtos.Domain.Mapper;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.UnitfWork;
using DesafioAtos.Service;
using Microsoft.EntityFrameworkCore;
using Np.Cryptography;

var builder = WebApplication.CreateBuilder(args);
var dbKey = builder.Configuration["cryptography:AppDbKey"];
var cryptography = new Cryptography();
var connectionString = cryptography.Decrypt(dbKey, builder.Configuration.GetConnectionString("AppDb"));
var environment = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

builder.Services.AddSingleton<ICryptography, Cryptography>();
builder.Services.AddSingleton<IResponseFactory, ResponseFactory>();
builder.Services.AddSingleton<IMapper, Mapper>();
builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("DesafioAtos.Infra")));

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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




