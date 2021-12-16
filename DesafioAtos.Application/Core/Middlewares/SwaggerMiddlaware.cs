using Microsoft.OpenApi.Models;

namespace DesafioAtos.Application.Core.Middlewares
{
    public class SwaggerMiddlaware
    {
        public static void ConfiguarSwagger(IServiceCollection service)
        {
            service.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Api para cadastro de pontos de coleta",
                    Description = "Coleta API Swagger",
                    Contact = new OpenApiContact
                    {
                        Name = "Atos Team",
                        Email = "Atos@gmail.com",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Atos",
                        Url = new Uri("https://github.com/FrtsVictor/ProjetoFinalAtos")
                    }
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
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