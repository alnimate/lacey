using Lacey.Alexa.Common.Metasploit.Infrastructure;
using Lacey.Alexa.Common.Metasploit.Providers;
using Lacey.Alexa.Common.Shodan.Infrastructure;
using Lacey.Alexa.Common.Shodan.Services;
using Lacey.Alexa.Explorer.Services.Services;
using Lacey.Alexa.Explorer.Services.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Alexa.Explorer.Services.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddExplorerServices(
            this IServiceCollection services,
            string metasploitUrl,
            string metasploitSecretsFile,
            string shodanSecretsFile)
        {
            services
                .AddMetasploitServices(
                    metasploitUrl,
                    metasploitSecretsFile)

                .AddShodanServices(shodanSecretsFile)

                .AddTransient<IExplorerService, ExplorerService>(
                    provider => new ExplorerService(
                        provider.GetService<IMetasploitProvider>(),
                        provider.GetService<IShodanService>(),
                        provider.GetService<ILogger<ExplorerService>>()));
            return services;
        }
    }
}