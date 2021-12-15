using Microsoft.Extensions.Configuration;

namespace Test
{
    public class TestSettings
    {
        public static IConfiguration Configuration = null!;

        static void Appsettings()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
        }

        public static string Get(string config)
        {
            return Configuration[config];
        }
    }
}