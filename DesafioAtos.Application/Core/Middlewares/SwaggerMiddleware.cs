using System.Reflection;
using Microsoft.OpenApi.Models;

namespace DesafioAtos.Application.Core.Middlewares
{
    /// <summary>
    /// Centralizador de configurações para o Swagger Api
    /// </summary>
    public static class SwaggerMiddleware
    {
        /// <summary>
        /// Metodo para adicionar as configurações ao ServceCollection
        /// </summary>
        /// <param name="service"></param>
        public static void ConfigurarSwagger(IServiceCollection service)
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            service.AddSwaggerGen(s =>
            {
                s.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Api para cadastro de pontos de coleta",
                    Description = "Garbage Collector Swagger",
                    Contact = new OpenApiContact
                    {
                        Name = "Garbage Collector",
                        Email = "garbage-collector@net.com",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Garbage Collector",
                        Url = new Uri("https://github.com/FrtsVictor/ProjetoFinalAtos")
                    }
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Token de autenticacao JWT (Example: 'Bearer meuTokenAqui')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }
    }
}