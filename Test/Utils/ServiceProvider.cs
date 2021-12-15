using DesafioAtos.Service.Services.Token;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Test.Utils
{
    public static class ServiceFactory    
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            
            serviceCollection.AddTransient<ITokenService, TokenService>();
            

            return serviceCollection;
        }

    }

}