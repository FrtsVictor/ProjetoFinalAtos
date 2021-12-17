using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace DesafioAtos.Application.Core.Middlewares
{
    public static class AuthenticationMiddlaware
    {
        public static void ConfigurarAutenticacao(IServiceCollection app, string tokenKey)
        {
            var tokenByteArr = Encoding.ASCII.GetBytes(tokenKey);

            app.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(tokenByteArr),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}