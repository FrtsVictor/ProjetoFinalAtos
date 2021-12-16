using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Test
{
    public class TestSettings
    {
        private IConfiguration _config;

        public TestSettings()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(Configuration);
        }

        public IConfiguration Configuration
        {
            get
            {
                if (_config != null) return _config;
                var builder = new ConfigurationBuilder().AddJsonFile($"testsettings.json", optional: false);
                _config = builder.Build();

                return _config;
            }
        }
    }
}