using Microsoft.Extensions.Configuration;

namespace crypto_cli.Configuration
{
    public class Config
    {
        private static IConfigurationBuilder Builder { get; } = BuildConfig(new ConfigurationBuilder());
        private static IConfigurationRoot Root { get; } = Builder.Build();
        public static IConfiguration Instance => Root;

        private static IConfigurationBuilder BuildConfig(IConfigurationBuilder builder)
        {
            return builder
                    .AddJsonFile("appsettings.json", true, true)
                    .AddEnvironmentVariables();
        }
    }
}
