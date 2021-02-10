using Lacey.Alexa.Common.Metasploit.Infrastructure;
using Lacey.Alexa.Common.Metasploit.Providers;
using Lacey.Alexa.Common.Shodan.Infrastructure;
using Lacey.Alexa.Common.Shodan.Services;
using Lacey.Alexa.Explorer.Services.Services;
using Lacey.Alexa.Explorer.Services.Services.Concrete;
using Lacey.Medusa.Google.Api.Infrastructure;
using Lacey.Medusa.Google.Api.Services;
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
            string googleSecretsFile,
            string shodanSecretsFile)
        {
            services
                .AddMetasploitServices(
                    metasploitUrl,
                    metasploitSecretsFile)
                .AddGoogleServices(googleSecretsFile)
                .AddShodanServices(shodanSecretsFile)

                .AddTransient<IExplorerService, ExplorerService>(
                    provider => new ExplorerService(
                        provider.GetService<IMetasploitProvider>(),
                        provider.GetService<IGoogleProvider>(),
                        provider.GetService<IShodanLoginService>(),
                        provider.GetService<IShodanService>(),
                        provider.GetService<ILogger<ExplorerService>>()));
            return services;
        }
    }
}