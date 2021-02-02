using Lacey.Alexa.Explorer.Run.Configuration;
using Lacey.Alexa.Explorer.Services.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Alexa.Explorer.Run.Infrastructure
{
    internal static class ServicesExtensions
    {
        public static IServiceCollection AddAppServices(
            this IServiceCollection services,
            AppConfiguration config)
        {
            services.AddExplorerServices(
                config.Metasploit.MetasploitUrl,
                config.Metasploit.MetasploitSecretsFile,
                config.Shodan.ShodanSecretsFile);

            return services;
        }
    }
}