using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace DesafioAtos.Application.Core.Middlewares
{
    public class AuthenticationMiddlaware
    {
        public static void ConfigurarAutenticacao(IServiceCollection app, string tokenKey)
        {
            var tokenBytearr = Encoding.ASCII.GetBytes(tokenKey);

            app.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(tokenBytearr),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}