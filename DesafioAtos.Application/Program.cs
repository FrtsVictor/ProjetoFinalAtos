using DesafioAtos.Application.Controllers;
using DesafioAtos.Domain.Mapper;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.UnitfWork;
using Microsoft.EntityFrameworkCore;
using Np.Cryptography;

var builder = WebApplication.CreateBuilder(args);
var dbKey = builder.Configuration["cryptography:AppDbKey"];
var cryptography = new Cryptography();
var connectionString = cryptography.Decrypt(dbKey, builder.Configuration.GetConnectionString("AppDb"));
var environment = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

builder.Services.AddSingleton<IResponseFactory, ResponseFactory>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<IMapper, Mapper>();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers()
.ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();




